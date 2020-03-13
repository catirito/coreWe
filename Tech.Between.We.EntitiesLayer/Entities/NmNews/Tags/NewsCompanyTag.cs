using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;
using Tech.Between.We.EntitiesLayer.Entities.Companies;

namespace Tech.Between.We.EntitiesLayer.Entities.NmNews.Tags
{
    public class NewsCompanyTag : EntityBase
    {
        public virtual Company Company{get;set;}
        public Guid? CompanyId { get; set; }

    }
}
