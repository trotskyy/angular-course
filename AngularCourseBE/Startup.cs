using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(AngularCourseBE.Startup))]

namespace AngularCourseBE
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string audience = JwtHelper.Audience;
            string issuer = JwtHelper.Issuer;

            var signingCredentials = JwtHelper.CreateCredentials();
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = signingCredentials.Key,

                    ValidIssuer = issuer,
                    ValidateIssuer = true,

                    ValidAudience = audience,
                    ValidateAudience = true,

                    ValidateLifetime = true
                },
            });


            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
