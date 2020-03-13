using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech.Between.We.ServiceLayer.Managers;

namespace Tech.Between.We.HttpServices.Authentication.Controllers.Bases
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public abstract class WebApiBaseController : Controller
    {
        public WebApiBaseController()
        {
            serviceManagers = new List<ServiceManager>();

        }
        private List<ServiceManager> serviceManagers = null;

        private ServiceManager serviceManager = null;

        protected ServiceManager GetServiceManager()
        {
            return serviceManager ?? (serviceManager = new ServiceManager());
        }

        protected List<ServiceManager> GetServiceManagers(int instancias)
        {

            List<ServiceManager> serviceManagers = new List<ServiceManager>();

            for (int i = 0; i < instancias; i++)
            {
                serviceManagers.Add(new ServiceManager());
            }
            this.serviceManagers.AddRange(serviceManagers);

            return serviceManagers;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceManagers?.ForEach(sm => sm?.Dispose());
                this.serviceManager?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
