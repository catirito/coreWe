using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Tech.Between.We.EntitiesLayer.Entities.Bases
{
   public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime? DbInsertedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long? DefaultOrder { get; set; }
        public long? ConeixId { get; set; }


        public EntityBase() {
            this.Id = Guid.NewGuid();
        }
    }
}
