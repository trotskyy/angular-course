using AngularCourseBE;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AngularCourse
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            AddJwtAuth(services);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private void AddJwtAuth(IServiceCollection services)
        {
            string audience = JwtHelper.Audience;
            string issuer = JwtHelper.Issuer;

            var signingCredentials = JwtHelper.CreateCredentials();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = signingCredentials.Key,

                        ValidIssuer = issuer,
                        ValidateIssuer = true,

                        ValidAudience = audience,
                        ValidateAudience = true,

                        ValidateLifetime = true
                    };
                });
        }
    }
}
