using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Clinic.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Clinic.Services;


namespace Clinic.Installer
{
    public class MvcInstaller 
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(key: nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddScoped<IIdentityService, IdentityService>();

            services.AddAuthentication(x =>
              {
                  x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              }
                ) 
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {

                            // будет ли валидироваться время существования
                            ValidateLifetime = true,
                            // установка ключа безопасности
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                            ValidateAudience = false,
                            ValidateIssuer = false
                        };

                    });

            

        }
    }
}
