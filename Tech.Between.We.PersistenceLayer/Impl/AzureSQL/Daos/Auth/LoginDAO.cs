using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.Auth;
using Tech.Between.We.PersistenceLayer.Api.Auth;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Orm.DbContexts;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Daos.Auth
{
    class LoginDAO : DaoBase, ILoginDAO
    {
        public LoginDAO(WeDbContext weDbContext) : base(weDbContext)
        {
        }

        public Task<Login> GetLoginById(Guid id)
        {
            return weDbContext.Logins.FindAsync(id);
        }

        public Task<Login> GetLoginByName(string name)
        {
           return weDbContext.Logins.Where(l => l.Name == name).FirstOrDefaultAsync();
           // return weDbContext.Logins.FirstOrDefaultAsync(l => l.Name == name);
        }

        public void Save(Login login)
        {
            this.SetEntityState(login);
        }
    }
}
