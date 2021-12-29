using System;
using Microsoft.Extensions.DependencyInjection;
using Ecommerce.Authentication;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.ApplicationService.Services;
using Ecommerce.ValidationService.Services;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.DomainService.Services;
using Ecommerce.DomainService.Mappings;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Repository.EF;

namespace Ecommerce.Ioc.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            AddAuthenticationDependencies(services);
            AddValidationDependencies(services);
            AddAddressDependencies(services); 
            AddProductDependencies(services);
            AddUserDependencies(services);
            AddPurchaseDependencies(services);
        }

        private static void AddAuthenticationDependencies(IServiceCollection services)
        {
            services.AddTransient<IAuthenticationApplicationService, AuthenticationApplicationService>();
        }

        private static void AddValidationDependencies(IServiceCollection services)
        {
            services.AddTransient<AddressValidationService, AddressValidationService>();
            services.AddTransient<CategoryValidationService, CategoryValidationService>();
            services.AddTransient<PurchaseValidationService, PurchaseValidationService>();
            services.AddTransient<ProductValidationService, ProductValidationService>();
            services.AddTransient<UserValidationService, UserValidationService>();
            services.AddTransient<ColorValidationService, ColorValidationService>();
            services.AddTransient<SizeValidationService, SizeValidationService>();
            services.AddTransient<LoginValidationService, LoginValidationService>();
        }

        private static void AddAddressDependencies(IServiceCollection services)
        {
            services.AddTransient<IAddressApplicationService, AddressApplicationService>();
            services.AddTransient<IAddressDomainService, AddressDomainService>();
            services.AddTransient<IAddressRepository, AddressRepository>();
        }
        private static void AddPurchaseDependencies(IServiceCollection services)
        {
            services.AddTransient<IPurchaseApplicationService, PurchaseApplicationService>();
            services.AddTransient<IPurchaseDomainService, PurchaseDomainService>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();

            services.AddTransient<IPurchaseSummaryApplicationService, PurchaseSummaryApplicationService>();
            services.AddTransient<IPurchaseSummaryDomainService, PurchaseSummaryDomainService>();
            services.AddTransient<IPurchaseSummaryRepository, PurchaseSummaryRepository>();
            services.AddTransient<IPurchaseSummaryMapping, PurchaseSummaryMapping>();
        }

        private static void AddUserDependencies(IServiceCollection services)
        {
            services.AddTransient<IUserApplicationService, UserApplicationService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        private static void AddProductDependencies(IServiceCollection services)
        {
            services.AddTransient<IProductApplicationService, ProductApplicationService>();
            services.AddTransient<IProductDomainService, ProductDomainService>();
            services.AddTransient<IProdutoRepository, ProductRepository>();

            services.AddTransient<ICategoryApplicationService, CategoryApplicationService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IColorApplicationService, ColorApplicationService>();
            services.AddTransient<IColorDomainService, ColorDomainService>();
            services.AddTransient<IColorRepository, ColorRepository>();

            services.AddTransient<ISizeApplicationService, SizeApplicationService>();
            services.AddTransient<ISizeDomainService, SizeDomainService>();
            services.AddTransient<ISizeRepository, SizeRepository>();
        }
    }
}