using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;
using Tech.Between.We.EntitiesLayer.Entities.Persons;

namespace Tech.Between.We.EntitiesLayer.Entities.NmNews.Tags
{
    public class NewsPersonTag:EntityBase
    {
        public virtual Person Person { get; set; }
        public Guid? PersonId { get; set; }
    }
}
