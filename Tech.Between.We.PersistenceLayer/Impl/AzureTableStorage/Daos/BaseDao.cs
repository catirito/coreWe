using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureTableStorage.Daos
{
   abstract class BaseDao
    {
        protected CloudTableClient GetCloudTableClient(string accountConnectionString)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(accountConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            return tableClient;
        }
    }
}
