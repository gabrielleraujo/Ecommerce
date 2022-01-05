using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Newtonsoft.Json;
using Ecommerce.CrossCutting.DTO.Product;
using WebApp.Clients.Interfaces;
using Ecommerce.CrossCutting.DTO.Category;
using Ecommerce.CrossCutting.DTO.Color;
using Ecommerce.CrossCutting.DTO.Size;

namespace WebApp.Clients.HttpClients
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _httpClient;

        public ProductApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReadProductDTO> PostProductAsync(CreateProductDTO productDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("product", content);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<ReadProductDTO>() : null;
        }

        public async Task<Result> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"product/{id}");

            return response.IsSuccessStatusCode ? Result.Ok() : Result.Fail("Erro ao deletar produto.");
        }

        public async Task<ReadProductDTO> GetProductByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"product/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ReadProductDTO>();
        }

        public async Task<IList<ReadProductDTO>> GetProductsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("product");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<ReadProductDTO>>();
        }

        public async Task<IList<ReadCategoryDTO>> GetCategoriesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("category");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<ReadCategoryDTO>>();
        }

        public async Task<IList<ReadColorDTO>> GetColorsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("color");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<ReadColorDTO>>();
        }

        public async Task<IList<ReadSizeDTO>> GetSizesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("size");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<ReadSizeDTO>>();
        }
    }
}