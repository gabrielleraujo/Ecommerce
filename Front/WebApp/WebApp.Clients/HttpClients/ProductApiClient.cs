using Ecommerce.CrossCutting.DTO.Product;
using FluentResults;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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

        async public Task<ReadProductDTO> PostProductAsync(HttpContent produto)
        {
            //the base address already defined in the client
            //This is the remaining part of the address.
            //We are passing the JSON value to the HTTP POST here.
            var response = await _httpClient.PostAsync("product", produto);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<ReadProductDTO>() : null;
        }

        async public Task<Result> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"product/{id}");

            return response.IsSuccessStatusCode ? Result.Ok() : Result.Fail("Erro ao deletar produto.");
        }
    }
}