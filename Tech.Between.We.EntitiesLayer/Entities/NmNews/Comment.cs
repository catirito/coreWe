using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;
using Tech.Between.We.EntitiesLayer.Entities.Persons;

namespace Tech.Between.We.EntitiesLayer.Entities.NmNews
{
   public class Comment:EntityBase
    {
        public virtual User Author { get; set; }
        public Guid? AuthorId { get; set; }
        public string Text { get; set; }    
        public DateTime? Date { get; set; }
        public Guid? NewsId { get; set; }
    }
}
