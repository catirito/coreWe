using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.Auth;

namespace Tech.Between.We.PersistenceLayer.Api.Auth
{
   public interface ILoginDAO
    {
        void Save(Login login);
        Task<Login> GetLoginById(Guid id);
        Task<Login> GetLoginByName(String name);

    }
}
