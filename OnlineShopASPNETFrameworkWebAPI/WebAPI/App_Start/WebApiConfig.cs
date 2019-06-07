using Com.CompanyName.OnlineShop.WebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Com.CompanyName.OnlineShop.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new UnhandledExceptionHandler());

            config.Filters.Add(new DbUpdateExceptionFilterAttribute());
            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"/d+" } 
            );

            config.Routes.MapHttpRoute(
                name: "DefaultNameApi",
                routeTemplate: "api/{controller}/{name}",
                defaults: new { name = RouteParameter.Optional }
            );
        }
    }
}
