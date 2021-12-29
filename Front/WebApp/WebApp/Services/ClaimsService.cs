using System.Security.Claims;
using Ecommerce.CrossCutting.DTO.User;
using Microsoft.AspNetCore.Authentication.Cookies;

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

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return claimsPrincipal;
        }
    }
}