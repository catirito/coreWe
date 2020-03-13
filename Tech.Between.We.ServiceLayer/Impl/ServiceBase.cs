using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tech.Between.We.PersistenceLayer.Impl.AzureBlobs.Managers;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Managers;
using Tech.Between.We.PersistenceLayer.Impl.AzureTableStorage.Managers;
using Tech.Between.We.PersistenceLayer.Managers;
using Tech.Between.We.UtilitiesLayer.Utilities;

namespace Tech.Between.We.ServiceLayer.Impl
{
    abstract class ServiceBase
    {
        private List<PersistenceManager> persistenceManagers;
        public ServiceBase(List<PersistenceManager> persistenceManagers) {
            this.persistenceManagers = persistenceManagers;
        }

        protected PersistenceManager GetPersistenceManager(PersistenceTechnologies persistenceTechnology) {

            PersistenceManager persistenceManagers = null;

            switch (persistenceTechnology) {
                case PersistenceTechnologies.AZURE_SQL:
                    persistenceManagers=
                        this.persistenceManagers.Where(pm => pm is AzureSqlPersistenceManager).FirstOrDefault();
                    break;
                case PersistenceTechnologies.AZURE_BLOBS:
                    persistenceManagers =
                       this.persistenceManagers.Where(pm => pm is AzureBlobsPersistenceManager).FirstOrDefault();
                    break;
                case PersistenceTechnologies.AZURE_TABLE_STORAGE:
                    persistenceManagers =
                      this.persistenceManagers.Where(pm => pm is AzureTableStoragePersistenceManager).FirstOrDefault();
                    break;
            }
            return persistenceManagers;
        }
    }
}
