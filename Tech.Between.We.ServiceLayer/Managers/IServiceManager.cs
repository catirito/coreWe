using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.ServiceLayer.Api.Audits;
using Tech.Between.We.ServiceLayer.Api.Auth;
using Tech.Between.We.ServiceLayer.Api.NmNews;
using Tech.Between.We.UtilitiesLayer.Utilities;

namespace Tech.Between.We.ServiceLayer.Managers
{
    public interface IServiceManager:IDisposable
    {
        INewsService GetNewsService();
        ILoginService GetLoginService();
        IAuditService GetAuditService();

        void SaveChanges(PersistenceTechnologies persistenceTechnologies = PersistenceTechnologies.AZURE_SQL);
    }
}
