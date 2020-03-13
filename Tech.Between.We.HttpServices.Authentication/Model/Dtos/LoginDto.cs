using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech.Between.We.HttpServices.Authentication.Model.Dtos
{
    public class LoginDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public String LoginName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public String Password { get; set; }
    }
}
