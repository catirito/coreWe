using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureBlobs.Daos
{
   public abstract class BaseDao
    {
        protected CloudBlobClient GetCloudBlobClient(String storageAccountConnection)
        {

            CloudStorageAccount storageAccount = null;
            CloudStorageAccount.TryParse(storageAccountConnection, out storageAccount);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            return blobClient;
        }
    }
}
