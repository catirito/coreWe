using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Managers;
using Tech.Between.We.PersistenceLayer.Managers;
using Tech.Between.We.ServiceLayer.Api.Audits;
using Tech.Between.We.ServiceLayer.Api.Auth;
using Tech.Between.We.ServiceLayer.Api.NmNews;
using Tech.Between.We.ServiceLayer.Impl.Audits;
using Tech.Between.We.ServiceLayer.Impl.Auth;
using Tech.Between.We.ServiceLayer.Impl.NmNews;
using Tech.Between.We.UtilitiesLayer.Utilities;

namespace Tech.Between.We.ServiceLayer.Managers
{
    public class ServiceManager : IServiceManager
    {
        private List<PersistenceManager> persistenceManagers;
        private INewsService newsService;
        private ILoginService loginService;
        private IAuditService auditService;

        public ServiceManager(string connectionString=null)
        {
            persistenceManagers = new List<PersistenceManager>();
            if(connectionString!=null)
            persistenceManagers.Add(PersistenceManager.GetPersistenceManager(PersistenceTechnologies.AZURE_SQL,connectionString));

            persistenceManagers.Add(PersistenceManager.GetPersistenceManager(PersistenceTechnologies.AZURE_BLOBS));
            persistenceManagers.Add(PersistenceManager.GetPersistenceManager(PersistenceTechnologies.AZURE_TABLE_STORAGE));


        }
        public void Dispose()
        {
            persistenceManagers?.ForEach(pm => pm.Dispose());
        }

        public IAuditService GetAuditService()
        {
            return auditService ?? (auditService = new AuditService(persistenceManagers));
        }

        public ILoginService GetLoginService()
        {
            return loginService ?? (loginService = new LoginService(persistenceManagers));

        }

        public INewsService GetNewsService()
        {
            return newsService ?? (newsService = new NewsService(this.persistenceManagers));
        }

        public void SaveChanges(PersistenceTechnologies persistenceTechnologies = PersistenceTechnologies.AZURE_SQL)
        {
            switch (persistenceTechnologies)
            {
                case PersistenceTechnologies.AZURE_SQL:
                    this.persistenceManagers.Where(pm => pm is AzureSqlPersistenceManager)
                        .FirstOrDefault()?.SaveChanges();
                    break;
                case PersistenceTechnologies.AZURE_BLOBS:
                    
                    break;
                case PersistenceTechnologies.AZURE_TABLE_STORAGE:
                    
                    break;

            }

        }
    }
}
