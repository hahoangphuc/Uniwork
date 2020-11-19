using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Vehicle.Data.Infastractor;

namespace Vehicle.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IDbFactory, DbFactory>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}