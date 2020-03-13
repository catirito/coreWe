using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.Audit;

namespace Tech.Between.We.PersistenceLayer.Api.Audits
{
    public interface IEntityBaseAuditDao
    {
        Task<bool> Save(EntityBaseAudit entityBaseAudit);
    }
}
