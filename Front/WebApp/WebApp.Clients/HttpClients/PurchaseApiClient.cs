using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using FluentResults;
using Ecommerce.CrossCutting.DTO.Purchase;
using WebApp.Clients.Interfaces;

namespace WebApp.Clients.HttpClients
{
    public class PurchaseApiClient : IPurchaseApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;

        public PurchaseApiClient(HttpClient httpClient, IHttpContextAccessor accessor)
        {
            _httpClient = httpClient;
            _accessor = accessor;
        }

        private void AddBearerToken()
        {
            var token = _accessor.HttpContext.User.Claims.First(c => c.Type == "Token").Value;

            _httpClient
                .DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        
        async public Task<Result> PostPurchaseAsync(CreatePurchaseDTO purchaseDto)
        {
            AddBearerToken();

            StringContent content = new StringContent(JsonConvert.SerializeObject(purchaseDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("purchase", content);
            return response.IsSuccessStatusCode ? Result.Ok() : Result.Fail(response.IsSuccessStatusCode.ToString());
        }
    }
}