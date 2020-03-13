using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;

namespace Tech.Between.We.EntitiesLayer.Entities.Audit
{
   public class EntityBaseAudit
    {
        public Guid Id { get; set; }
        public EntityBase Entity { get; set; }
        public Type EntityType { get; set; } 
        public string BlobUrl{ get; set; }
    
        public EntityBaseAudit(EntityBase entityBase) {
            Id = Guid.NewGuid();
            Entity = entityBase;
            EntityType = entityBase.GetType();
        }
    }
}
