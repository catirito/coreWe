using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.Audit;
using Tech.Between.We.PersistenceLayer.Api.Audits;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureBlobs.Daos.Audits
{
    class EntityBaseAuditDao :BaseDao, IEntityBaseAuditDao
    {
        public async Task<bool> Save(EntityBaseAudit entityBaseAudit)
        {
            var accountConnectionString = "DefaultEndpointsProtocol=https;AccountName=between;AccountKey=kS8y6N3ILffm7wfe6n+ZpzkauFNKe4EHsaLz1Zs8c3cp/8tnFQM2OT9WL8xaHgLPenWMrCsKKKtUb8FNdRhwuA==;EndpointSuffix=core.windows.net";
            var containerName = "entitybasechangeaudits";
            var blobName = entityBaseAudit?.Entity?.Id +"-"+Guid.NewGuid()+".json";

            var blobClient = GetCloudBlobClient(accountConnectionString);
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(entityBaseAudit);

            await blob.UploadTextAsync(json);

            entityBaseAudit.BlobUrl = blob.Uri.AbsoluteUri;

            return true;
        }
    }
}
