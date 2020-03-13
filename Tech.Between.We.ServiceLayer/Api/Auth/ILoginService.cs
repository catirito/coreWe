using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.Auth;

namespace Tech.Between.We.ServiceLayer.Api.Auth
{
   public interface ILoginService
    {
        Task<Login> Login(String loginName, String password);
        Task<Login> GetLoginById(Guid id);
        void SaveLogin(Login login);


    }
}
