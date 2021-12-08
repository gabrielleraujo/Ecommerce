using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.CrossCutting.DTO.Address;

namespace Ecommerce.IoC.MapperProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile() 
        {
            CreateMap<CreateAddressDTO, Address>();
            CreateMap<Address, ReadAddressDTO>();
        }
    }
}