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
        private static readonly Uri _ecommerceURL = new Uri(Environment.GetEnvironmentVariable("ECOMMERCE_URL"));
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
                { c.BaseAddress = _ecommerceURL; });

            services.AddHttpClient<IProductApiClient, ProductApiClient>
                ("product", c =>
                { c.BaseAddress = _ecommerceURL; });

            services.AddHttpClient<IAuthApiClient, AuthApiClient>
                ("auth", c =>
                { c.BaseAddress = _ecommerceURL; });

            services.AddHttpClient<IPurchaseApiClient, PurchaseApiClient>
                ("purchase", c =>
                { c.BaseAddress = _ecommerceURL; });

            services.AddHttpClient<IAddressApiClient, AddressApiClient>
                ("address", c =>
                { c.BaseAddress = _ecommerceURL; });
        }
    }
}