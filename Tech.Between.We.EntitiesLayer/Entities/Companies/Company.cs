using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;

namespace Tech.Between.We.EntitiesLayer.Entities.Companies
{
  public  class Company:EntityBase
    {
        public String Name { get; set; }
        public String Nif { get; set; }
    }
}
