using System;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Clients.HttpClients;
using WebApp.Clients.Interfaces;
using WebApp.Services;
using WebApp.Services.Interfaces;

namespace WebApp.Ioc
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddHttpClient<IUserApiClient, UserApiClient>
                ("user", c =>
                { c.BaseAddress = new Uri("https://localhost:5001/api/v1.0/"); });

            services.AddHttpClient<IProductApiClient, ProductApiClient>
                ("product", c =>
                { c.BaseAddress = new Uri("https://localhost:5001/api/v1.0/"); });

            services.AddHttpClient<IAuthApiClient, AuthApiClient>
                ("auth", c =>
                { c.BaseAddress = new Uri("https://localhost:5001/api/v1.0/"); });
        }
    }
}