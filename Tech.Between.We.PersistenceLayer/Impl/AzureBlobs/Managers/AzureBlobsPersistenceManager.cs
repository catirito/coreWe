using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.PersistenceLayer.Api.Audits;
using Tech.Between.We.PersistenceLayer.Api.Auth;
using Tech.Between.We.PersistenceLayer.Api.NmNews;
using Tech.Between.We.PersistenceLayer.Impl.AzureBlobs.Daos.Audits;
using Tech.Between.We.PersistenceLayer.Managers;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureBlobs.Managers
{
    public class AzureBlobsPersistenceManager : PersistenceManager
    {
        IHttpRequestAuditDao httpRequestAuditDao;
        IEntityBaseAuditDao entityBaseAuditDao;
        #region OperacionSoportadas
        public override IHttpRequestAuditDao GetHttpRequestAuditDao()
        {
            return httpRequestAuditDao ?? (httpRequestAuditDao = new HttpRequestAuditDao());
        }
        public override IEntityBaseAuditDao GetEntityBaseAuditDao()
        {
            return entityBaseAuditDao ?? (entityBaseAuditDao = new EntityBaseAuditDao());
        }
        #endregion

        #region Operaciones No Soportadas
        public override void Dispose()
        {
        }

      
        public override ILoginDAO GetLoginDAO()
        {
            throw new NotImplementedException();
        }

        public override INewsDAO GetNewsDao()
        {
            throw new NotImplementedException();
        }

        public override void SaveChanges()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
