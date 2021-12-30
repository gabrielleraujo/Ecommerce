using AutoMapper;
using Ecommerce.CrossCutting.DTO.User;
using WebApp.ViewModels;

namespace WebApp.Ioc.Profiles
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<LoginViewModel, LoginDTO>();
        }
    }
}