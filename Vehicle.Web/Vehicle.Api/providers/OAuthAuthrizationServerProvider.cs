using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Vehicle.Bussiness.Reposistory;
using Vehicle.Data.Infastractor;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace Vehicle.Api.providers
{
    public class OAuthServerProvider : OAuthAuthorizationServerProvider
    {
        IAccountReposistory _accountReposistory; //field = null

        public IAccountReposistory accountReposistory //property
        {
            get {
               return  _accountReposistory ?? (_accountReposistory = new AccountReposistory(new DbFactory()));
            }           
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var username = context.UserName;
            var password = context.Password;

            var md = accountReposistory.CheckLogin(username, password);
            if(md != null)
            {
                var claims = new ClaimsIdentity(context.Options.AuthenticationType);
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, md.Id.ToString()));
                claims.AddClaim(new Claim(ClaimTypes.Email, md.UserName));

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {                    
                    {"key", md.UserName.ToString() }
                });

                var ticket = new AuthenticationTicket(claims, props);

                context.Validated(ticket);
            }
            else
            {
                context.Rejected();
            }            
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var item in context.Properties.Dictionary)
            {
                if (!item.Key.StartsWith("."))  //check các thuộc tính ko có "." (ngày phát hành & ngày kết thúc) đầu dòng => add vào
                    context.AdditionalResponseParameters.Add(item.Key, item.Value);
            }
            return base.TokenEndpoint(context);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
    }
}