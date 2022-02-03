using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using WebApp.ViewModels;

namespace WebApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserListViewModel> IndexAsync();
        Task<UserDetailsViewModel> AddAsync(UserRegistrationViewModel produtoViewModel);
        Task<Result> DeleteAsync(int id);

        Task<IList<UserDetailsViewModel>> ListAsync();
        Task<UserDetailsViewModel> GetByIdAsync(int id);
    }
}