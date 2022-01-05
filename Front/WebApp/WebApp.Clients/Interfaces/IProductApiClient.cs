using Ecommerce.CrossCutting.DTO.Category;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using Ecommerce.CrossCutting.DTO.Color;
using Ecommerce.CrossCutting.DTO.Product;
using Ecommerce.CrossCutting.DTO.Size;

namespace WebApp.Clients.Interfaces
{
    public interface IProductApiClient
    {
        Task<ReadProductDTO> PostProductAsync(CreateProductDTO productDto);
        Task<Result> DeleteProductAsync(int id);

        Task<ReadProductDTO> GetProductByIdAsync(int id);
        Task<IList<ReadProductDTO>> GetProductsAsync();
        Task<IList<ReadCategoryDTO>> GetCategoriesAsync();
        Task<IList<ReadColorDTO>> GetColorsAsync();
        Task<IList<ReadSizeDTO>> GetSizesAsync();
    }
}