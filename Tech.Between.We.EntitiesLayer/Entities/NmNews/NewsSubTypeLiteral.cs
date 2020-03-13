using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;
using Tech.Between.We.EntitiesLayer.Entities.Commons;

namespace Tech.Between.We.EntitiesLayer.Entities.NmNews
{
    public class NewsSubTypeLiteral:EntityBase
    {
        public virtual Language Language { get; set; }
        public Guid? LanguageId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
