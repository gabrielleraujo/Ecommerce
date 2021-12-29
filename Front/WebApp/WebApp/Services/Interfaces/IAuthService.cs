using FluentResults;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Result<string>> AuthenticateAsync(LoginViewModel loginViewModel);
        Task LogoutAsync();
    }
}