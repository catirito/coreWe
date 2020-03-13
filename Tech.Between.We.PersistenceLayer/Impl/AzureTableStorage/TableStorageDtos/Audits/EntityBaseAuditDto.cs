using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Audit;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureTableStorage.TableStorageDtos.Audits
{
    class EntityBaseAuditDto: TableEntity
    {
        public EntityBaseAuditDto(EntityBaseAudit entityBaseAudit)
        {
            PartitionKey = entityBaseAudit.Entity.Id.ToString();
            RowKey = Guid.NewGuid().ToString();
            ETag = "*";
            BlobUrl = entityBaseAudit.BlobUrl;
            EntityType = entityBaseAudit.EntityType.AssemblyQualifiedName;
        }
        public string BlobUrl { get; set; }
        public string EntityType { get; set; }
    }
}
