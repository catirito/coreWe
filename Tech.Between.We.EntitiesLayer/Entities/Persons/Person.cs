using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;

namespace Tech.Between.We.EntitiesLayer.Entities.Persons
{
  public class Person:EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Surname2 { get; set; }

    }
}
