using Ecommerce.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Ioc.Extensions
{
    public static class DataBase
    {
        public static void AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcommerceContext>(opt => opt
                        .UseSqlServer(configuration.GetConnectionString("EcommerceConnection")));
        }
    }
}