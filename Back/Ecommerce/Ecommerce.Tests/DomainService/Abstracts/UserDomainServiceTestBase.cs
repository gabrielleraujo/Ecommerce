using AutoMapper;
using Ecommerce.CrossCutting.DTO.User;
using Ecommerce.IoC.MapperProfiles;

namespace Ecommerce.Tests.Templates
{
    public abstract class UserDomainServiceTestBase
    {
        protected MapperConfiguration ConfigureAutoMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new AddressProfile());
            });
        }

        protected CreateUserDTO CreatJoaoUserDto()
        {
            return new CreateUserDTO
            {
                Name = "João",
                Surname = "Souza",
                Username = "jao",
                Email = "joao@gmail.com",
                Password = "123",
                RePassword = "123",
                Role = "comprador",
            };
        }

        protected CreateUserDTO CreatBiaUserDto()
        {
            return new CreateUserDTO
            {
                Name = "Bia",
                Surname = "Araújo",
                Username = "bia",
                Email = "bia@gmail.com",
                Password = "123",
                RePassword = "123",
                Role = "comprador",
            };
        }
    }
}