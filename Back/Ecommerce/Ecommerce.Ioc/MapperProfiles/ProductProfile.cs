using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.CrossCutting.DTO.Product;

namespace Ecommerce.IoC.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<Product, ReadProductDTO>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<ReadProductDTO, Product>();
        }
    }
}