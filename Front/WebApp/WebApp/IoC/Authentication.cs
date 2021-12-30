using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Ioc
{
    public static class Authentication
    {
        public static void AddCookieAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Authentication/Login";
                    x.LogoutPath = "/Authentication/Logout";
                });
        }
    }
}