using FluentResults;
using Ecommerce.CrossCutting.DTO.User;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.Authentications.Services;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.ApplicationService
{
    public class AuthenticationApplicationService : IAuthenticationApplicationService
    {
        private readonly IUserDomainService _userDomainService;
        private readonly IConfiguration _configuration;

        public AuthenticationApplicationService(
            IUserDomainService usuarioDomainService,
            IConfiguration configuration)
        {
            _userDomainService = usuarioDomainService;
            _configuration = configuration;
        }

        public Result<string> CreateToken(LoginDTO loginDto)
        {
            var userDto = _userDomainService.GetByLogin(loginDto.Username, loginDto.Password);
            
            if (userDto == null) { return Result.Fail("Invalid username or password"); }

            var token = TokenService.CreateToken(userDto, _configuration);
            return Result.Ok(token);
        }
    }
}