using System;
using System.Collections.Generic;
using System.Text;

namespace Tech.Between.We.EntitiesLayer.Dtos.Tokens
{
    public class TokenJwtConfigurationDto
    {
        public String SecretKey { get; set; }
        public String Iiuser { get; set; }
        public String Audience { get; set; }
      
    }
}
