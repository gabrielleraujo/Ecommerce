using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Newtonsoft.Json;
using Ecommerce.CrossCutting.DTO.Product;
using WebApp.Clients.Interfaces;

namespace WebApp.Clients.HttpClients
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _httpClient;

        public ProductApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReadProductDTO> GetProductByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"product/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ReadProductDTO>();
        }

        async public Task<IList<ReadProductDTO>> GetProductsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("product");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<ReadProductDTO>>();
        }

        async public Task<ReadProductDTO> PostProductAsync(CreateProductDTO productDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("product", content);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<ReadProductDTO>() : null;
        }

        async public Task<Result> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"product/{id}");

            return response.IsSuccessStatusCode ? Result.Ok() : Result.Fail("Erro ao deletar produto.");
        }
    }
}