using Ecommerce.CrossCutting.DTO.User;
using FluentResults;
using System.Threading.Tasks;

namespace WebApp.Clients.Interfaces
{
    public interface IAuthApiClient
    {
        Task<Result<string>> AuthenticateAsync(LoginDTO loginDto);
    }
}