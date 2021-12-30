using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.CrossCutting.DTO.User;

namespace WebApp.Clients.Interfaces
{
    public interface IUserApiClient
    {
        Task<IList<ReadUserDTO>> GetUsersAsync();
        Task<ReadUserDTO> GetUserByIdAsync(int id);
        Task<ReadUserDTO> PostUserAsync(CreateUserDTO userDto);
        Task<Result> DeleteUserAsync(int id);
    }
}