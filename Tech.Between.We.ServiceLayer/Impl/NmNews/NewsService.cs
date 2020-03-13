using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.NmNews;
using Tech.Between.We.PersistenceLayer.Managers;
using Tech.Between.We.ServiceLayer.Api.NmNews;
using Tech.Between.We.UtilitiesLayer.Utilities;

namespace Tech.Between.We.ServiceLayer.Impl.NmNews
{
    class NewsService : ServiceBase, INewsService
    {
        public NewsService(List<PersistenceManager> persistenceManagers) : base(persistenceManagers)
        {
        }

        public Task<List<News>> GetNews(PersistenceTechnologies persistenceTechnology = PersistenceTechnologies.AZURE_SQL)
        {
            return GetPersistenceManager(persistenceTechnology).GetNewsDao().GetNews();

        }

        public Task<List<News>> GetNewsByAuthorId(Guid id, PersistenceTechnologies persistenceTechnology = PersistenceTechnologies.AZURE_SQL)
        {
           
                return GetPersistenceManager(persistenceTechnology).GetNewsDao().GetNewsByAuthorId(id);
            
          
        }

        public Task<News> GetNewsById(Guid id, PersistenceTechnologies persistenceTechnology = PersistenceTechnologies.AZURE_SQL)
        {
            return GetPersistenceManager(persistenceTechnology).GetNewsDao().GetNewsById(id);
        }

        public Task<List<News>> GetNewsByRelatedAuthorId(Guid authorId, int elements, PersistenceTechnologies persistenceTechnology = PersistenceTechnologies.AZURE_SQL)
        {
           return  GetPersistenceManager(persistenceTechnology).GetNewsDao().GetNewsByRelatedAuthorId(authorId,elements);
        }

        public void SaveNews(News news, PersistenceTechnologies persistenceTechnology = PersistenceTechnologies.AZURE_SQL)
        {
             GetPersistenceManager(persistenceTechnology).GetNewsDao().SaveNews(news);
        }
    }
}
