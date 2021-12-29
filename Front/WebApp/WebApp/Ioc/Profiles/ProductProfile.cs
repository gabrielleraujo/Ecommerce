using AutoMapper;
using Ecommerce.CrossCutting.DTO.Product;
using WebApp.ViewModels;

namespace WebApp.IoC.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ReadProductDTO, ProductHomeViewModel>();      // in index
            CreateMap<ReadProductDTO, ProductDetailsViewModel>();   // in list

            CreateMap<CreateProductDTO, ProductRegistrationViewModel>();
            CreateMap<ProductRegistrationViewModel, CreateProductDTO>();
        }
    }
}