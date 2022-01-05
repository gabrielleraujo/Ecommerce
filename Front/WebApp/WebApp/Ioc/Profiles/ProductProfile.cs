using AutoMapper;
using WebApp.ViewModels;
using Ecommerce.CrossCutting.DTO.Category;
using Ecommerce.CrossCutting.DTO.Color;
using Ecommerce.CrossCutting.DTO.Product;
using Ecommerce.CrossCutting.DTO.Size;

namespace WebApp.Ioc.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ReadProductDTO, ProductHomeViewModel>();

            CreateMap<ReadProductDTO, ProductDetailsViewModel>()
                .ForMember(dest => dest.CategoryText, opt => opt.MapFrom(src => src.Category.CategoryText))
                .ForMember(dest => dest.ColorText, opt => opt.MapFrom(src => src.Color.ColorText))
                .ForMember(dest => dest.SizeText, opt => opt.MapFrom(src => src.Size.SizeText));

            CreateMap<ReadCategoryDTO, CategoryDetailsViewModel>();
            CreateMap<ReadColorDTO, ColorDetailsViewModel>();
            CreateMap<ReadSizeDTO, SizeDetailsViewModel>();

            CreateMap<CreateProductDTO, ProductRegistrationViewModel>();
            CreateMap<ProductRegistrationViewModel, CreateProductDTO>();
        }
    }
}