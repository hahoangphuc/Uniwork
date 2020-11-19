using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Vehicle.Api.Utility;
using Vehicle.Bussiness.Reposistory;
using Vehicle.Data.Infastractor;

namespace Vehicle.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            container.RegisterType<IDbFactory, DbFactory>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ICategoryReposistory, CategoryReposistory>();
            container.RegisterType<ICustomerReposistory, CustomerReposistory>();
            

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
