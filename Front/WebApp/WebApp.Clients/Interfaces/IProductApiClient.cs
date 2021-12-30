using Ecommerce.CrossCutting.DTO.Product;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Clients.Interfaces
{
    public interface IProductApiClient
    {
        Task<IList<ReadProductDTO>> GetProductsAsync();
        Task<ReadProductDTO> GetProductByIdAsync(int id);
        Task<ReadProductDTO> PostProductAsync(CreateProductDTO productDto);
        Task<Result> DeleteProductAsync(int id);
    }
}