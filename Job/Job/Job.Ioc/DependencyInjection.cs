using Job.Context;
using Job.DomainService;
using Job.Service;
using Job.Service.Processes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;

namespace Job.Ioc
{
    public static class DependencyInjection
    {
        public static void ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddSingleton<IRestClient>(new RestClient(configuration["URL_API_Ecommerce"]));
            services.AddSingleton<IRestClient>(new RestClient("https://localhost:5001/api/v1.0"));

            services.AddScoped<IPurchaseClient, PurchaseClient>();
            services.AddScoped<IPurchaseDomainService, PurchaseDomainService>();

            services.AddHostedService<ConsumeScopedServiceHostedService>();
            services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
        }
    }
}