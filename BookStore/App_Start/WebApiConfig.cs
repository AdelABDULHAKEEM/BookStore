using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes //Attribute-based routing
            config.MapHttpAttributeRoutes();


            //convention-based routing
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //http://www.adelAbdulhakeem.com/api/BookStore/archive/Java/120/JohnDeep
            config.Routes.MapHttpRoute(
               name: "BookStore",
               routeTemplate: "api/{controller}/{action}/{title}/{numberofpages}/{author}",
               defaults: new {
                   numberofpages = RouteParameter.Optional ,
                   author = RouteParameter.Optional
               },
               constraints: new
               {
                   title = @"\d{a,A}" ,
                   numberofpages = @"\d{0,2}",
                   author = @"\d{a,A}"
               }
           );


        }
    }
}
