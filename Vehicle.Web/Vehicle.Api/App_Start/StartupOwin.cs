using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Vehicle.Api.providers;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Vehicle.Api.App_Start.StartupOwin))]

namespace Vehicle.Api.App_Start
{
    public class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            var provider = new OAuthServerProvider();   //gọi hàm từ OAuthAuthorizationServerProvider

            //tương tự như 1 controller để gọi lên tạo token
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(2),
                Provider = provider
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            GlobalConfiguration.Configure(WebApiConfig.Register);		// copy trong Global.asax đưa vào
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
