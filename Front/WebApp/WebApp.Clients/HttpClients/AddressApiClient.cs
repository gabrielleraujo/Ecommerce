using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Ecommerce.CrossCutting.DTO.Address;
using WebApp.Clients.Interfaces;

namespace WebApp.Clients.HttpClients
{
    public class AddressApiClient : IAddressApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;

        public AddressApiClient(HttpClient httpClient, IHttpContextAccessor accessor)
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
        
        async public Task<ReadAddressDTO> PostAddressAsync(CreateAddressDTO aaddressDto)
        {
            AddBearerToken();

            StringContent content = new StringContent(JsonConvert.SerializeObject(aaddressDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("address", content);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<ReadAddressDTO>() : null;
        }
    }
}