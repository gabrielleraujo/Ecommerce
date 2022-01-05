using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Newtonsoft.Json;
using Ecommerce.CrossCutting.DTO.User;
using WebApp.Clients.Interfaces;

namespace WebApp.Clients.HttpClients
{
    public class AuthApiClient : IAuthApiClient
    {
        private readonly HttpClient _httpClient;

        public AuthApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<string>> AuthenticateAsync(LoginDTO loginDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("authentication", content);

            return response.IsSuccessStatusCode ?
                Result.Ok(await response.Content.ReadAsStringAsync()) :
                Result.Fail("Authentication error.");
        }
    }
}