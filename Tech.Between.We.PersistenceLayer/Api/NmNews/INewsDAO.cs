using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.NmNews;

namespace Tech.Between.We.PersistenceLayer.Api.NmNews
{
   public interface INewsDAO
    {
        Task<News> GetNewsById(Guid id);
        Task<List<News>> GetNewsByAuthorId(Guid id);
        Task<List<News>> GetNewsByRelatedAuthorId(Guid authorId,int elements);
        Task<List<News>> GetNews();
        void SaveNews(News news);

    }
 }
