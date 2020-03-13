using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;

namespace Tech.Between.We.EntitiesLayer.Entities.Projects
{
   public class Project:EntityBase
    {
        public string Title { get; set; }
        public string Reference { get; set; }
        public DateTime? RequestDate { get; set; }

    }
}
