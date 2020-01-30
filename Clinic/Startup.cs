using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Clinic.Models;  
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
//using Swashbuckle.SwaggerUi;
using System.Reflection;
using System.IO;


using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Clinic.Options;
using Clinic.Logic;
using System.Text;

namespace Clinic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //todo: Переделать по примеру Тимура
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ClinicContext>(options => options.UseSqlServer(connection));

            services.AddControllersWithViews();

            //Сваггер
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                //JWT в сваггер 
                //var security = new Dictionary<string, IEnumerable<string>>
                //{
                //    { "Bearer", new string[0]}
                //};
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                 
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            //Scheme = "oauth2",
                            //Name = "Bearer",
                            //In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

            //services.AddSwaggerExamplesFromAssemblyOf<Startup>();
            services.AddControllers(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });

                        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseAuthentication();

            //Сваггер
            app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();

    //        "SwaggerOptions": {
    //            "JsonRoute": "swagger/{documentName}/swagger.json",
    //"Description": "Our API",
    //"UIEndpoint": "v1/swagger.json"
        }
    }
}
