using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;

namespace Tech.Between.We.EntitiesLayer.Entities.NmNews
{
    public class NewsSubType:EntityBase
    {
        public virtual List<NewsSubTypeLiteral> Literals { get; set; }    
        public virtual NewsType NewsType { get; set; }
        public Guid? NewsTypeId { get; set; }


        public NewsSubType() {
            Literals = new List<NewsSubTypeLiteral>();
        }
    }
}
