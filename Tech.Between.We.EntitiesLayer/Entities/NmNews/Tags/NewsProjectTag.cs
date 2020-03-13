using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;
using Tech.Between.We.EntitiesLayer.Entities.Projects;

namespace Tech.Between.We.EntitiesLayer.Entities.NmNews.Tags
{
    public class NewsProjectTag:EntityBase
    {
        public virtual Project Project { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
