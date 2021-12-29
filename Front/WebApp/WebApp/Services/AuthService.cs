using AutoMapper;
using System.Threading.Tasks;
using Ecommerce.CrossCutting.DTO.User;
using WebApp.Services.Interfaces;
using WebApp.Clients.Interfaces;
using WebApp.ViewModels;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace WebApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthApiClient _authApiClient;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public AuthService(IAuthApiClient authApiClient, IMapper mapper, IHttpContextAccessor accessor)
        {
            _authApiClient = authApiClient;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task<Result<string>> AuthenticateAsync(LoginViewModel loginViewModel)
        {
            LoginDTO loginDto = _mapper.Map<LoginDTO>(loginViewModel);

            var token = await _authApiClient.AuthenticateAsync(loginDto);

            if (token.IsSuccess) 
            { 
                var claims = ClaimsService.CreateClaims(loginDto, token.Value);
                _accessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claims);
            }

            return token;
        }

        public async Task LogoutAsync()
        {
            _accessor.HttpContext.SignOutAsync();
        }
    }
}