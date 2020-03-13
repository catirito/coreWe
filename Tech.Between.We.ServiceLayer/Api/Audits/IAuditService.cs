using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Audit;
using Tech.Between.We.EntitiesLayer.Entities.Bases;

namespace Tech.Between.We.ServiceLayer.Api.Audits
{
    public interface IAuditService
    {
        void SaveHttpRequestAudit(HttpRequestAudit httpRequestAudit);

        void SaveEntityBaseAudit(EntityBase entityBase);
    }
}
