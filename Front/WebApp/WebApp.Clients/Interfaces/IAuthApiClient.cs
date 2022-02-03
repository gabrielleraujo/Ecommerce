using System.Threading.Tasks;
using Ecommerce.CrossCutting.DTO.User;
using FluentResults;

namespace WebApp.Clients.Interfaces
{
    public interface IAuthApiClient
    {
        Task<Result<string>> AuthenticateAsync(LoginDTO loginDto);
    }
}