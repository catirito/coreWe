using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Dtos.Tokens;
using Tech.Between.We.EntitiesLayer.Entities.Auth;
using Tech.Between.We.HttpServices.Authentication.Controllers.Bases;
using Tech.Between.We.HttpServices.Authentication.Model.Dtos;

namespace Tech.Between.We.HttpServices.Authentication.Controllers.Auth
{
    public class AuthController : WebApiBaseController
    {
        private TokenJwtConfigurationDto tokenJwtConfigurationDto { get; set; }
        public AuthController(IOptions<TokenJwtConfigurationDto> tokenJWTConfiguration)
        {
            this.tokenJwtConfigurationDto = tokenJWTConfiguration.Value;
        }

        [Route("Login/{appName}")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto,string appName)
        {
            if (!ModelState.IsValid) {
                BadRequest();
            }

            var login = await GetServiceManager().GetLoginService().Login(loginDto.LoginName, loginDto.Password);

            if (login != null) {

                var token = GenerateJwtToken(login, 1,appName);
                var renewToken = await GenerateRenewToken(DateTime.UtcNow.AddHours(8));
                token.RenewToken = renewToken.Token;

                login.RenewTokens?.ForEach(t => {
                    t.DeletedDate = DateTime.Now;
                });

                login.RenewTokens.Add(renewToken);

                GetServiceManager().GetLoginService().SaveLogin(login);
                GetServiceManager().SaveChanges();



                return Ok(token);
            }
            else
            {
                return BadRequest("Usuario o Password incorrectos");
            }

        }



        [Route("Login/Renew")]
        [HttpPost]
        public async Task<IActionResult> LoginRenew([FromBody] TokenDto tokenDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var tokenJwt = tokenDto.TokenJwt;

            var tokenPrincipal = GetPrincipalFromExpiredToken(tokenJwt);

            var loginId = tokenPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var appName= tokenPrincipal?.FindFirst("AppName")?.Value;


            var login = await GetServiceManager().GetLoginService().GetLoginById(Guid.Parse(loginId));

            if (login.RenewTokens.Where(rt => rt.Token == tokenDto.RenewToken
            && rt.Expire >= DateTime.UtcNow).FirstOrDefault() != null)
            {
                var token = GenerateJwtToken(login, 1,"");
                var renewToken = await GenerateRenewToken(DateTime.UtcNow.AddHours(8));
                token.RenewToken = renewToken.Token;
                login.RenewTokens?.ForEach(t => {
                    t.DeletedDate = DateTime.Now;
                });
                login.RenewTokens.Add(renewToken);
                GetServiceManager().GetLoginService().SaveLogin(login);
                GetServiceManager().SaveChanges();
                return Ok(token);

            }
            else {
                return BadRequest("No ha sido posible la recreación de los tokens");

            }
                
            
          

        }


        private TokenDto GenerateJwtToken(Login login,int duration,string appName)
        {
            string secretKey = tokenJwtConfigurationDto.SecretKey;
            string issuer = tokenJwtConfigurationDto.Iiuser;
            string audience = tokenJwtConfigurationDto.Audience;

            var claims = new List<Claim>
            {
                //Unique Id for token
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Iss,issuer),
                new Claim(JwtRegisteredClaimNames.UniqueName,login.Name),
                new Claim(JwtRegisteredClaimNames.Sub,login.Id.ToString()),
                new Claim("AppName",appName),
                new Claim("AppName", appName)
            };

            login.Roles?.ForEach(
                r => claims.Add(new Claim(ClaimTypes.Role,r.Name))
                );

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(duration),
                signingCredentials: creds
            );

            TokenDto jwtToken = new TokenDto();
            jwtToken.TokenJwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;

        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenJwtConfigurationDto.SecretKey)),
                ValidateLifetime = false 
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        private Task<RenewToken> GenerateRenewToken(DateTime expireDate)
        {
            RenewToken token = new RenewToken();
            token.Expire = expireDate;

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                token.Token = Convert.ToBase64String(randomNumber);
            }

            return Task.FromResult(token);
        }

    }

}
