using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.Audit;
using Tech.Between.We.PersistenceLayer.Api.Audits;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureBlobs.Daos.Audits
{
    class HttpRequestAuditDao : BaseDao, IHttpRequestAuditDao
    {
        public async Task<bool> Save(HttpRequestAudit httpRequestAudit)
        {
            var accountConnectionString = "DefaultEndpointsProtocol=https;AccountName=between;AccountKey=kS8y6N3ILffm7wfe6n+ZpzkauFNKe4EHsaLz1Zs8c3cp/8tnFQM2OT9WL8xaHgLPenWMrCsKKKtUb8FNdRhwuA==;EndpointSuffix=core.windows.net";
            var containerName = "wehttprequestaudits";
            var blobName = httpRequestAudit.Id+".json";

            var blobClient = GetCloudBlobClient(accountConnectionString);
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(httpRequestAudit);

            await blob.UploadTextAsync(json);

            httpRequestAudit.BlobUrl = blob.Uri.AbsoluteUri;

            return true;

        }
    }
}
