using System;
using System.Collections.Generic;
using System.Text;

namespace Tech.Between.We.EntitiesLayer.Entities.Audit
{
   public class HttpRequestAudit
    {
        public Guid? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UrlRequest { get; set; }
        public string PathUrl { get; set; }
        public string Action { get; set; }
        public string ClientIP { get; set; }
        public string Login { get; set; }
        public object Entity { get; set; }
        public Type EntityType { get; set; }
        public String BlobUrl { get; set; }
        public String Status { get; set; }
        public Double? ComputeTime { get; set; }

        public HttpRequestAudit() {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
    }
}
