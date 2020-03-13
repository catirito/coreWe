using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Audit;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureTableStorage.TableStorageDtos.Audits
{
    class HttpRequestAuditDto:TableEntity
    {
        public HttpRequestAuditDto(HttpRequestAudit httpRequestAudit )
        {
            PartitionKey = httpRequestAudit.Id.ToString();
            RowKey = Guid.NewGuid().ToString();
            ETag = "*";
            CreationDate = httpRequestAudit.CreatedDate;
            BlobUrl = httpRequestAudit.BlobUrl;
            Login = httpRequestAudit.Login;
            ClientIP = httpRequestAudit.ClientIP;
            UrlRequest = httpRequestAudit.UrlRequest;
        }

        public DateTime? CreationDate { get; set; }
        public string BlobUrl { get; set; }
        public string Login { get; set; }
        public string ClientIP { get; set; }
        public string UrlRequest { get; set; }

    }
}
