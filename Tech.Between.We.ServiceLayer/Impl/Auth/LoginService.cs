using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.Auth;
using Tech.Between.We.PersistenceLayer.Managers;
using Tech.Between.We.ServiceLayer.Api.Auth;
using Tech.Between.We.UtilitiesLayer.Utilities;

namespace Tech.Between.We.ServiceLayer.Impl.Auth
{
    class LoginService : ServiceBase, ILoginService
    {
        public LoginService(List<PersistenceManager> persistenceManagers) : base(persistenceManagers)
        {
        }

        public async Task<Login> GetLoginById(Guid id)
        {
            var login = await GetPersistenceManager(PersistenceTechnologies.AZURE_SQL).GetLoginDAO().GetLoginById(id);
            return login;
        }

        public async Task<Login> Login(string loginName, string password)
        {
            var login = await GetPersistenceManager(PersistenceTechnologies.AZURE_SQL).GetLoginDAO().GetLoginByName(loginName);
            if (login?.Password == password) return login;
            return null;
        }

        public void SaveLogin(Login login)
        {
             GetPersistenceManager(PersistenceTechnologies.AZURE_SQL).GetLoginDAO().Save(login);
        }
    }
}
