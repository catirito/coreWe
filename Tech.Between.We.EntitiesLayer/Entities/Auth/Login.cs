using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;

namespace Tech.Between.We.EntitiesLayer.Entities.Auth
{
    public class Login : EntityBase
    {
        public String Name { get; set; }
        public String Password { get; set; }
        public virtual List<Role> Roles {get;set;}
        public virtual List<RenewToken> RenewTokens { get; set; }


        public Login() {
            Roles = new List<Role>();
            RenewTokens = new List<RenewToken>();
        }


    }
}
