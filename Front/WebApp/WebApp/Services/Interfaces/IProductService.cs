using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<IList<ProductDetailsViewModel>> ListAsync();

        Task<HomeViewModel> IndexAsync();

        Task<ProductDetailsViewModel> GetByIdAsync(int id);

        Task<ProductDetailsViewModel> AddAsync(ProductRegistrationViewModel produtoViewModel);
        Task<Result> DeleteAsync(int id);
    }
}