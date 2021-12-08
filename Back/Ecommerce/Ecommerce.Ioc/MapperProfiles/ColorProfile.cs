using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.CrossCutting.DTO.Color;

namespace Ecommerce.IoC.MapperProfiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<CreateColorDTO, Color>();
            CreateMap<Color, ReadColorDTO>();
        }
    }
}