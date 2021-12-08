using Ecommerce.CrossCutting.DTO.User;
using FluentResults;

namespace Ecommerce.ApplicationService
{
    public interface IAuthenticationApplicationService
    {
        Result<string> CreateToken(LoginDTO loginDto);
    }
}
