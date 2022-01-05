using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels;
using FluentResults;

namespace WebApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductListViewModel> IndexAsync();
        Task<ProductDetailsViewModel> AddAsync(ProductRegistrationViewModel produtoViewModel);
        Task<Result> DeleteAsync(int id);

        Task<ProductDetailsViewModel> GetByIdAsync(int id);
        Task<IList<ProductDetailsViewModel>> ListAsync();
        Task<IList<CategoryDetailsViewModel>> ListCategoriesAsync();
        Task<IList<ColorDetailsViewModel>> ListColorsAsync();
        Task<IList<SizeDetailsViewModel>> ListSizesAsync();
    }
}