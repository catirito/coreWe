using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech.Between.We.HttpServices.Authentication.Model.Dtos
{
    public class TokenDto
    {
        public String TokenJwt { get; set; }
        public String RenewToken { get; set; }
    }
}
