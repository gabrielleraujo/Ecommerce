using FluentResults;
using Microsoft.Extensions.Configuration;
using Ecommerce.CrossCutting.DTO.User;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.Authentication.Services;
using System.Threading.Tasks;

namespace Ecommerce.Authentication
{
    public class AuthenticationApplicationService : IAuthenticationApplicationService
    {
        private readonly IUserDomainService _userDomainService;
        private readonly IConfiguration _configuration;

        public AuthenticationApplicationService(IUserDomainService usuarioDomainService, IConfiguration configuration)
        {
            _userDomainService = usuarioDomainService;
            _configuration = configuration;
        }

        public async Task<Result<string>> CreateToken(LoginDTO loginDto)
        {
            var userDto = _userDomainService.GetByLogin(loginDto.Username, loginDto.Password);

            if (userDto == null) { return Result.Fail("Invalid username or password"); }

            var token = AuthService.CreateToken(userDto, _configuration);

            return Result.Ok(token);
        }
    }
}