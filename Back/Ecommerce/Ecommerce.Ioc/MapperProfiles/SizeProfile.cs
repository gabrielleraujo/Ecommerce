using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.CrossCutting.DTO.Size;

namespace Ecommerce.IoC.MapperProfiles
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<CreateSizeDTO, Size>();
            CreateMap<Size, ReadSizeDTO>();
            CreateMap<ReadSizeDTO, Size> ();
        }
    }
}