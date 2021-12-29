using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Ecommerce.Ioc.Extensions
{
    public static class SwaggerGen
    {
        public static void ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ecommerce API",
                    Description = "Documentação da API",
                    Version = "1.0"
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Ecommerce API",
                    Description = "Documentação da API",
                    Version = "2.0"
                });

                options.EnableAnnotations();
            });
        }
    }
}