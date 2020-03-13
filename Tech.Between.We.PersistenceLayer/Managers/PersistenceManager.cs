using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Audit;
using Tech.Between.We.PersistenceLayer.Api.Audits;
using Tech.Between.We.PersistenceLayer.Api.Auth;
using Tech.Between.We.PersistenceLayer.Api.NmNews;
using Tech.Between.We.PersistenceLayer.Impl.AzureBlobs.Managers;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Managers;
using Tech.Between.We.PersistenceLayer.Impl.AzureTableStorage.Managers;
using Tech.Between.We.UtilitiesLayer.Utilities;

namespace Tech.Between.We.PersistenceLayer.Managers
{
    public abstract class PersistenceManager:IDisposable
    {
        public abstract INewsDAO GetNewsDao();
        public abstract ILoginDAO GetLoginDAO();
        public abstract IHttpRequestAuditDao GetHttpRequestAuditDao();
        public abstract IEntityBaseAuditDao GetEntityBaseAuditDao();

        public static PersistenceManager GetPersistenceManager(PersistenceTechnologies persistenceTechnology,string connectionString=null)
        {
            PersistenceManager persistenceManager=null;

            switch (persistenceTechnology) {
                case PersistenceTechnologies.AZURE_SQL:
                    persistenceManager = new AzureSqlPersistenceManager(connectionString);
                    break;
                case PersistenceTechnologies.AZURE_BLOBS:
                    persistenceManager = new AzureBlobsPersistenceManager();
                    break;
                case PersistenceTechnologies.AZURE_TABLE_STORAGE:
                    persistenceManager = new AzureTableStoragePersistenceManager();
                    break;
            }

            return persistenceManager;
        }

        public abstract void Dispose();
        public abstract void SaveChanges();
        
    }
}
