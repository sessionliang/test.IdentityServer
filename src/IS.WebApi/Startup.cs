using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(IS.WebApi.Startup))]
namespace IS.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //设置此webapi需要identityserver的授权才能访问
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServer3.AccessTokenValidation.IdentityServerBearerTokenAuthenticationOptions()
            {
                Authority = "http://localhost:5000",
                ValidationMode = IdentityServer3.AccessTokenValidation.ValidationMode.ValidationEndpoint,
                RequiredScopes = new[] { "api" }
            });

            //设置路由
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            

            //设置所有的controller，都需要令牌
            config.Filters.Add(new AuthorizeAttribute());

            //程序使用webapi
            app.UseWebApi(config);
        }
    }
}