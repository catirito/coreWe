using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.NmNews;
using Tech.Between.We.UtilitiesLayer.Utilities;

namespace Tech.Between.We.ServiceLayer.Api.NmNews
{
   public interface INewsService
    {
        Task<List<News>> GetNews(PersistenceTechnologies persistenceTechnology = PersistenceTechnologies.AZURE_SQL);
        Task<News> GetNewsById(Guid id,PersistenceTechnologies persistenceTechnology=PersistenceTechnologies.AZURE_SQL);
        Task<List<News>> GetNewsByAuthorId(Guid id,PersistenceTechnologies persistenceTechnology = PersistenceTechnologies.AZURE_SQL);
        void SaveNews(News news, PersistenceTechnologies persistenceTechnology = PersistenceTechnologies.AZURE_SQL);
        Task<List<News>> GetNewsByRelatedAuthorId(Guid authorId, int elements, PersistenceTechnologies persistenceTechnology 
             = PersistenceTechnologies.AZURE_SQL);

    }
}
