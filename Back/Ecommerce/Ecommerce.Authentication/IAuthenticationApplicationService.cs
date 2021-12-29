using Ecommerce.CrossCutting.DTO.User;
using FluentResults;
using System.Threading.Tasks;

namespace Ecommerce.Authentication
{
    public interface IAuthenticationApplicationService
    {
        Task<Result<string>> CreateToken(LoginDTO loginDto);
    }
}