using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Clients.HttpClients;
using WebApp.Clients.Interfaces;
using WebApp.Services;
using WebApp.Services.Interfaces;
using WebApp.ViewModels;

namespace WebApp.Ioc
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IAddressService, AddressService>();

            services.AddHttpClient<IUserApiClient, UserApiClient>
                ("user", c =>
                { c.BaseAddress = new Uri("https://localhost:5001/api/v1.0/"); });

            services.AddHttpClient<IProductApiClient, ProductApiClient>
                ("product", c =>
                { c.BaseAddress = new Uri("https://localhost:5001/api/v1.0/"); });

            services.AddHttpClient<IAuthApiClient, AuthApiClient>
                ("auth", c =>
                { c.BaseAddress = new Uri("https://localhost:5001/api/v1.0/"); });

            services.AddHttpClient<IPurchaseApiClient, PurchaseApiClient>
                ("auth", c =>
                { c.BaseAddress = new Uri("https://localhost:5001/api/v1.0/"); });

            services.AddHttpClient<IAddressApiClient, AddressApiClient>
                ("auth", c =>
                { c.BaseAddress = new Uri("https://localhost:5001/api/v1.0/"); });
        }
    }
}