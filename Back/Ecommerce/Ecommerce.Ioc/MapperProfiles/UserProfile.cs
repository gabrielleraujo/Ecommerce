using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.CrossCutting.DTO.User;

namespace Ecommerce.IoC.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, ReadUserDTO>();
            CreateMap<UpdateUserDTO, User>();

            CreateMap<CreateUserDTO, LoginDTO>();
        }
    }
}