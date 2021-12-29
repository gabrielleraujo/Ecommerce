using Ecommerce.CrossCutting.DTO.Product;
using FluentResults;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace WebApp.Clients.Interfaces
{
    public interface IProductApiClient
    {
        Task<IList<ReadProductDTO>> GetProductsAsync();
        Task<ReadProductDTO> GetProductByIdAsync(int id);
        public Task<ReadProductDTO> PostProductAsync(HttpContent produto);
        Task<Result> DeleteProductAsync(int id);
    }
}