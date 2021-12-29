using AutoMapper;
using Ecommerce.CrossCutting.DTO.User;
using WebApp.ViewModels;

namespace WebApp.IoC.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ReadUserDTO, UserHomeViewModel>();     // in index
            CreateMap<ReadUserDTO, UserDetailsViewModel>();  // in list
            
            CreateMap<CreateUserDTO, UserRegistrationViewModel>();
            CreateMap<UserRegistrationViewModel, CreateUserDTO>();
        }
    }
}