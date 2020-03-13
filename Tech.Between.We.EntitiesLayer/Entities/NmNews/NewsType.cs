using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;

namespace Tech.Between.We.EntitiesLayer.Entities.NmNews
{
    public class NewsType:EntityBase
    {
        public virtual List<NewsTypeLiteral> Literals { get; set; }

        public NewsType() {
            Literals = new List<NewsTypeLiteral>();
        }

    }
}
