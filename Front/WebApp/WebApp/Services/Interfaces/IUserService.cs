using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserListViewModel> IndexAsync();
        Task<IList<UserDetailsViewModel>> ListAsync();
        Task<UserDetailsViewModel> GetByIdAsync(int id);
        Task<UserDetailsViewModel> AddAsync(UserRegistrationViewModel produtoViewModel);
        Task<Result> DeleteAsync(int id);
    }
}