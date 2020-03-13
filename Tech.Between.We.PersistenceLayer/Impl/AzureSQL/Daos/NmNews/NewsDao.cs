using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.NmNews;
using Tech.Between.We.PersistenceLayer.Api.NmNews;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Orm.DbContexts;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Daos.NmNews
{
   public class NewsDAO : DaoBase, INewsDAO
    {
        public NewsDAO(WeDbContext weDbContext) : base(weDbContext)
        {
        }

        public  Task<List<News>> GetNews()
        {
         /* var commentsQuery=   this.weDbContext.Comment.
                OrderByDescending(n => n.Date).Select(c=>new { NewsId=c.NewsId,Date=c.DbInsertedDate });

          var newsQuery = this.weDbContext.News.
                  OrderByDescending(n => n.Date).Select(c => new { NewsId = c.Id as Guid?, Date = c.DbInsertedDate });

           var unionQuery= commentsQuery.Union(newsQuery).Distinct().ToList();

            var distintNewsIdDate= unionQuery
                .GroupBy(c => c.NewsId)
                .Select(group => new { newsId = group.Key, date = group.Max(g => g.Date) })
                .Distinct()
                .OrderBy(g=>g.date)
                .ToList();
                */
            return this.weDbContext.News.Take(10).ToListAsync();
        }

        public Task<List<News>> GetNewsByAuthorId(Guid id)
        {
            try
            {
                return this.weDbContext.News.Where(n => n.AuthorId == id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  Task<News> GetNewsById(Guid id)
        {
            try
            {
                return this.weDbContext.News.FindAsync(id);              
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        public async Task<List<News>> GetNewsByRelatedAuthorId(Guid authorId,int elements)
        {
          var news=  await this.weDbContext.News.Where(n => n.AuthorId == authorId).Select(n=>new {NewsId=n.Id as Guid?,
              Fecha =n.Date })
                .ToListAsync();

            var comments = await this.weDbContext.Comment.Where(c=>c.AuthorId == authorId).Select(c=>new { NewsId=c.NewsId,Fecha=c.Date})
              .ToListAsync();

            news.AddRange(comments);

           var idnews= news
                .GroupBy(c => c.NewsId)
                 .Select(group => new { NewsId = group.Key, date = group.Max(g => g.Fecha) })
                 .OrderByDescending(g => g.date)
                 .Take(elements)
                 .Select(n => n.NewsId).ToList();

            var newsObjects= await this.weDbContext.News.Where(n => idnews.Contains(n.Id)).ToListAsync();   

            return newsObjects;
        }

        public void SaveNews(News news)
        {            
           this.SetEntityState(news);
        }
    }
}
