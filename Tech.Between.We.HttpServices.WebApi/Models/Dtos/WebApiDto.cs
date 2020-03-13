using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech.Between.We.HttpServices.WebApi.Models.Dtos
{
    public abstract class WebApiDto
    {
        public List<ErrorDto> Errors { get; set; }

        public WebApiDto() {
            Errors = new List<ErrorDto>();
        }
        public class ErrorDto
        {
            public String Error { get; set; }
            public String Message { get; set; }

        }
    }
}
