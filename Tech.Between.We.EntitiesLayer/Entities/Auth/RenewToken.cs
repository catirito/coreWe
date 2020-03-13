using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;

namespace Tech.Between.We.EntitiesLayer.Entities.Auth
{
    public class RenewToken : EntityBase
    {
        public String Token { get; set; }
        public DateTime? Expire {get;set;}
    }
}
