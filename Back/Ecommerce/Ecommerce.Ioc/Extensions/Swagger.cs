using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Ecommerce.Ioc.Extensions
{
    public static class Swagger
    {
        public static void AddMySwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ecommerce API",
                    Description = "Documentação da API",
                    Version = "1.0",
                    Contact = new OpenApiContact { Name = "Gabrielle", Url = new Uri("https://gabrielleraujo.github.io/") }
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Ecommerce API",
                    Description = "Documentação da API",
                    Version = "2.0",
                    Contact = new OpenApiContact { Name = "Gabrielle", Url = new Uri("https://gabrielleraujo.github.io/") }
                });

                options.EnableAnnotations();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

            });
        }

        public static void UseMySwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce v1.0");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Ecommerce v2.0");
            }); 
        }
    }
}