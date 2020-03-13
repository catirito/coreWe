using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Dtos.ConnectionStrings;
using Tech.Between.We.EntitiesLayer.Entities.Audit;
using Tech.Between.We.EntitiesLayer.Entities.NmNews;
using Tech.Between.We.HttpServices.WebApi.Controllers.Bases;
using Tech.Between.We.HttpServices.WebApi.Models.Dtos;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Daos.NmNews;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Orm.DbContexts;
using Tech.Between.We.ServiceLayer.Managers;

namespace Tech.Between.We.HttpServices.WebApi.Controllers
{
   // [AllowAnonymous]
   // [Authorize(Roles = "AppUser")]
    public class NewsController : WebApiBaseController {
        public NewsController(IOptions<ConnectionsStringsConfigurationsDto> connectionsStringsConfigurationsDto) 
            : base(connectionsStringsConfigurationsDto)
        {
        }

        public class NewsDto: WebApiDto
        {
            public RequestDto Request { get; set; }
            public class RequestDto {
                public List<News> NewsList{ get; set; }
                public News News { get; set; }

            }
        }

  //      [Authorize(Roles = "AppAdmin")]
        [Route("")]
        [HttpPost]
        public  IActionResult Save([FromBody] List<News> news) {

            if (news == null) {
                return BadRequest();
            }

                news?.ForEach(n =>
                {
                    //try
                    //{
                        GetServiceManager().GetAuditService().SaveEntityBaseAudit(n);
                   // }
                    //catch (Exception ex) {

                    //}

                    GetServiceManager().GetNewsService().SaveNews(n);
                    GetServiceManager().SaveChanges();
                });
            
         

            /*
            List<News> news2 = new List<News>();

            List<News> news3 = new List<News>();

            for (int i = 0; i < 1000; i++) {
                news2.Add(new News() { Title = i.ToString() });
                news3.Add(new News() { Title = i.ToString() });

            }
            
            news2.ForEach(n =>
            {
                var sm = GetServiceManagers(1).FirstOrDefault();
                sm.GetNewsService().SaveNews(n);
                sm.SaveChanges();
            });

          var resultado=  Parallel.ForEach(news3, n => {
                SaveNewsAsync(n);
             });
             */

            return Ok(news);
        }

        public void SaveNewsAsync(News n) {
            var sm = GetServiceManagers(1).FirstOrDefault();
            sm.GetNewsService().SaveNews(n);
            sm.SaveChanges();
        }


        [Route("{id}")]
        [HttpGet]
        public  async Task<IActionResult> getNews(Guid id)
        {
            try
            {


                var news = await GetServiceManager().GetNewsService().GetNewsById(id);

                return Ok(news);
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> getNews()
        {
            try
            {
                var news = await GetServiceManager().GetNewsService().GetNews();

                return Ok(news.Take(10));
                /*
                for (int i = 0; i < 100; i++)
                {
                    serviceManagers.Add(new ServiceManager());
                }

                List<Task> parallelrequests = new List<Task>();
                servicesManagers?.ForEach(
                    sm => parallelrequests.Add(sm.GetNewsService().GetNews())
                    );

                 await Task.WhenAll(parallelrequests);
                 */
               
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [Route("Author/{id}/elements/{elements}")]
        [HttpGet]
        public async Task<IActionResult> getNews(Guid id, int elements)
        {
            try
            {
               var news= await  GetServiceManager().GetNewsService().GetNewsByRelatedAuthorId(id, elements);

                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("Test")]
        [HttpGet]
        public  IActionResult getNewsTest()
        {
           
                return Ok(new News());
          
        }
    }

}
