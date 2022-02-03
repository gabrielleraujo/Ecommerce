using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;
using Newtonsoft.Json;
using FluentResults;
using Ecommerce.CrossCutting.DTO.User;
using WebApp.Clients.Interfaces;

namespace WebApp.Clients.HttpClients
{
    public class UserApiClient : IUserApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;

        public UserApiClient(HttpClient httpClient, IHttpContextAccessor accessor)
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
        
        async public Task<ReadUserDTO> PostUserAsync(CreateUserDTO userDto)
        {
            AddBearerToken();

            StringContent content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("user", content);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<ReadUserDTO>() : null;
        }

        async public Task<Result> DeleteUserAsync(int id)
        {
            AddBearerToken();

            var response = await _httpClient.DeleteAsync($"user/{id}");
            return response.IsSuccessStatusCode ? Result.Ok() : Result.Fail("Error deleting user.");
        }
        
        public async Task<ReadUserDTO> GetUserByIdAsync(int id)
        {
            AddBearerToken();

            HttpResponseMessage response = await _httpClient.GetAsync($"user/{id}");
            return await response.Content.ReadAsAsync<ReadUserDTO>();
        }

        async public Task<IList<ReadUserDTO>> GetUsersAsync()
        {
            try { AddBearerToken(); }
            catch (Exception) { return null; }

            HttpResponseMessage response = await _httpClient.GetAsync("user");
            return await response.Content.ReadAsAsync<List<ReadUserDTO>>();
        }
    }
}