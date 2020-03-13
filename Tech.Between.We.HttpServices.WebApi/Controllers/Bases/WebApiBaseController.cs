using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Dtos.ConnectionStrings;
using Tech.Between.We.HttpServices.WebApi.Models.Filters;
using Tech.Between.We.ServiceLayer.Managers;

namespace Tech.Between.We.HttpServices.WebApi.Controllers.Bases
{
    [AllowAnonymous]
    [AzureLogFilter]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public abstract class WebApiBaseController:Controller
    {
        private ConnectionsStringsConfigurationsDto connectionsStringsConfigurationsDto;
        public WebApiBaseController(IOptions<ConnectionsStringsConfigurationsDto> connectionsStringsConfigurationsDto)
        {
            serviceManagers = new List<ServiceManager>();
            this.connectionsStringsConfigurationsDto = connectionsStringsConfigurationsDto.Value;
        }

        private List<ServiceManager> serviceManagers = null;

        private ServiceManager serviceManager = null;

        protected ServiceManager GetServiceManager()
        {
            return serviceManager ?? (serviceManager = new ServiceManager(GetBBDDConnectionString()));
        }

        protected List<ServiceManager> GetServiceManagers(int instancias) {

            List<ServiceManager> serviceManagers = new List<ServiceManager>();

            for(int i = 0; i < instancias; i++)
            {
                serviceManagers.Add(new ServiceManager(GetBBDDConnectionString()));
            }
            this.serviceManagers.AddRange(serviceManagers);

            return serviceManagers;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceManagers?.ForEach(sm=>sm?.Dispose());
                this.serviceManager?.Dispose();
            }
            base.Dispose(disposing);
        }

        protected string GetBBDDConnectionString()
        {
            String connectionString = null;

            var host = HttpContext.Request.Host.ToString().ToLower();

            if (host.Contains("localhost"))
            {
                connectionString = connectionsStringsConfigurationsDto.ApiWe_Local;
            }

            else
            {
                connectionString = connectionsStringsConfigurationsDto.ApiWe_Prod;
            }

            return connectionString;

        }
    }
}
