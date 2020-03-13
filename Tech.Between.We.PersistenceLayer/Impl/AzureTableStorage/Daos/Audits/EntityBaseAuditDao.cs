using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.Audit;
using Tech.Between.We.PersistenceLayer.Api.Audits;
using Tech.Between.We.PersistenceLayer.Impl.AzureTableStorage.TableStorageDtos.Audits;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureTableStorage.Daos.Audits
{
    class EntityBaseAuditDao : BaseDao, IEntityBaseAuditDao
    {
        public async Task<bool> Save(EntityBaseAudit entityBaseAudit)
        {
            var accountConnectionString = "DefaultEndpointsProtocol=https;AccountName=between;AccountKey=kS8y6N3ILffm7wfe6n+ZpzkauFNKe4EHsaLz1Zs8c3cp/8tnFQM2OT9WL8xaHgLPenWMrCsKKKtUb8FNdRhwuA==;EndpointSuffix=core.windows.net";
            var tablename = "entitybasechangeaudits";


            var tableClient = GetCloudTableClient(accountConnectionString);
            CloudTable table = tableClient.GetTableReference(tablename);

            EntityBaseAuditDto entityBaseAuditdto = new EntityBaseAuditDto(entityBaseAudit);

            var insertData = TableOperation.Insert(entityBaseAuditdto);

            var result = await table.ExecuteAsync(insertData);

            return true;
        }
    }
}
