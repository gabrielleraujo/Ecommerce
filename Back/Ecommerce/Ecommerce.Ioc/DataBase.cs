using Ecommerce.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.IoC
{
    public static class DataBase
    {
        public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcommerceContext>(opt => opt
                        .UseSqlServer(configuration.GetConnectionString("EcommerceConnection")));
        }
    }
}