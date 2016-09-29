using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Orix.MeuControle.Service
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var _repository = new FakeRepository())
            {
                var user = _repository.Authenticate(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "Usuário ou senhas incorretos.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
    public class FakeRepository : IDisposable
    {
        public void Dispose()
        {
           
        }

        internal object Authenticate(string userName, string password)
        {
            if (userName == "adm" && password == "123")
            {
                return new { };
            }
            else
            {
                return null;
            }
        }
    }
}