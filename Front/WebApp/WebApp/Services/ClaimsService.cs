using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Ecommerce.CrossCutting.DTO.User;

namespace WebApp.Services
{
    public static class ClaimsService
    {
        public static ClaimsPrincipal CreateClaims(LoginDTO loginDto, string token)
        {
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, loginDto.Username),
                new Claim("Token", token)
            },
            CookieAuthenticationDefaults.AuthenticationScheme);
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}