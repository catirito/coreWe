using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.Audit;
using Tech.Between.We.EntitiesLayer.Entities.Bases;
using Tech.Between.We.PersistenceLayer.Managers;
using Tech.Between.We.ServiceLayer.Api.Audits;
using Tech.Between.We.UtilitiesLayer.Utilities;

namespace Tech.Between.We.ServiceLayer.Impl.Audits
{
    class AuditService :ServiceBase, IAuditService
    {
        public AuditService(List<PersistenceManager> persistenceManagers) : base(persistenceManagers)
        {
        }

        public async void SaveEntityBaseAudit(EntityBase entityBase)
        {
            var entityBaseAudit = new EntityBaseAudit(entityBase);

            var blobSafeResult = await GetPersistenceManager(PersistenceTechnologies.AZURE_BLOBS).GetEntityBaseAuditDao().Save(entityBaseAudit);

            if (blobSafeResult)
            {
                _ = GetPersistenceManager(PersistenceTechnologies.AZURE_TABLE_STORAGE).GetEntityBaseAuditDao().Save(entityBaseAudit);
            }
        }

        public async void SaveHttpRequestAudit(HttpRequestAudit httpRequestAudit)
        {
           var blobSafeResult= await GetPersistenceManager(PersistenceTechnologies.AZURE_BLOBS).GetHttpRequestAuditDao().Save(httpRequestAudit);

            if (blobSafeResult)
            {
                _ = GetPersistenceManager(PersistenceTechnologies.AZURE_TABLE_STORAGE).GetHttpRequestAuditDao().Save(httpRequestAudit);  
            }
        }
    }
}
