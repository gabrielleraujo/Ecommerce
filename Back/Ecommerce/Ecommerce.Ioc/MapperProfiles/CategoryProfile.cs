using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.CrossCutting.DTO.Category;

namespace Ecommerce.IoC.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<Category, ReadCategoryDTO>();
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<ReadCategoryDTO, Category>();
        }
    }
}