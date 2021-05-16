using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Security.Claims;

[assembly: OwinStartup(typeof(WebApiToken.App_Start.Startup))]

namespace WebApiToken.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseWebApi(config);

        }
        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
                Provider = new SimpleAuthorizationServerProvider()
            };
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
        public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
                return Task.FromResult<object>(null);

            }
            public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin",new[] {"*"});
                if (context.UserName=="yasin" && context.Password=="1")
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("sub", context.UserName));
                    identity.AddClaim(new Claim("role", "user"));
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant","Hatalı Giriş");
                }
                return Task.FromResult<object>(null);
            }

        }
    }
}
