using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.CrossCutting.DTO.User;

namespace WebApp.Clients.Interfaces
{
    public interface IUserApiClient
    {
        Task<ReadUserDTO> PostUserAsync(CreateUserDTO userDto);
        Task<Result> DeleteUserAsync(int id);

        Task<ReadUserDTO> GetUserByIdAsync(int id);
        Task<IList<ReadUserDTO>> GetUsersAsync();
    }
}