using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech.Between.We.EntitiesLayer.Entities.Audit;
using Tech.Between.We.ServiceLayer.Managers;

namespace Tech.Between.We.HttpServices.WebApi.Models.Filters
{
    public class AzureLogFilter : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var serviceManager = new ServiceManager();

            HttpRequestAudit httpRequestAudit = new HttpRequestAudit();

            httpRequestAudit.UrlRequest = context.HttpContext.Request.Scheme + @"://" +
               context.HttpContext.Request.Host +
               context.HttpContext.Request.Path;

            httpRequestAudit.PathUrl = context.HttpContext.Request.Path;
            httpRequestAudit.Action = context.ActionDescriptor.DisplayName;
            httpRequestAudit.Entity = context.ActionArguments;
            //peticionHttpAudit.EntityType
           // httpRequestAudit.Login = GetUsuarioId(actionContext.HttpContext)?.ToString();
            httpRequestAudit.ClientIP = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            httpRequestAudit.Status = "PETICION";

           serviceManager.GetAuditService().SaveHttpRequestAudit(httpRequestAudit);

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var serviceManager = new ServiceManager();
            HttpRequestAudit httpRequestAudit = new HttpRequestAudit();

            httpRequestAudit.UrlRequest = context.HttpContext.Request.Scheme + @"://" +
               context.HttpContext.Request.Host +
               context.HttpContext.Request.Path;

            httpRequestAudit.PathUrl = context.HttpContext.Request.Path;
            httpRequestAudit.Action = context.ActionDescriptor.DisplayName;
            httpRequestAudit.Entity = context.Result;
            //peticionHttpAudit.EntityType
           // httpRequestAudit.Login = GetUsuarioId(context.HttpContext)?.ToString();
            httpRequestAudit.ClientIP = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            httpRequestAudit.Status = "RESPUESTA";

           serviceManager.GetAuditService().SaveHttpRequestAudit(httpRequestAudit);

            base.OnActionExecuted(context);
        }

    }
}
