using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.PersistenceLayer.Api.Audits;
using Tech.Between.We.PersistenceLayer.Api.Auth;
using Tech.Between.We.PersistenceLayer.Api.NmNews;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Daos.Auth;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Daos.NmNews;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Orm.DbContexts;
using Tech.Between.We.PersistenceLayer.Managers;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Managers
{
    public class AzureSqlPersistenceManager : PersistenceManager
    {
        private WeDbContext weDbContext;
        private INewsDAO newsDao;
        private ILoginDAO loginDao;

        public AzureSqlPersistenceManager(string connectionString){
            weDbContext = new WeDbContext(connectionString);
        }

        public override void Dispose()
        {
            this.weDbContext.Dispose();
        }

        public override IEntityBaseAuditDao GetEntityBaseAuditDao()
        {
            throw new NotImplementedException();
        }

        public override IHttpRequestAuditDao GetHttpRequestAuditDao()
        {
            throw new Exception("Dao no soportado en sql");
        }

        public override ILoginDAO GetLoginDAO()
        {
            return loginDao ?? (loginDao = new LoginDAO(weDbContext));
        }

        public override INewsDAO GetNewsDao()
        {
            return newsDao ?? (newsDao = new NewsDAO(weDbContext));
        }

        public override void SaveChanges()
        {
            this.weDbContext.SaveChanges();
        }
    }
}
