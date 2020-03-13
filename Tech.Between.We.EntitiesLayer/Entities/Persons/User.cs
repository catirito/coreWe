using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Auth;
using Tech.Between.We.EntitiesLayer.Entities.Bases;
using Tech.Between.We.EntitiesLayer.Entities.Commons;

namespace Tech.Between.We.EntitiesLayer.Entities.Persons
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual Person Person { get; set; }
        public Guid? PersonId { get; set; }
        public virtual Language Language { get; set; }
        public Guid? LanguageId { get; set; }

        public virtual Login Login { get; set; }
        public Guid? LoginId { get; set; }


    }
}
