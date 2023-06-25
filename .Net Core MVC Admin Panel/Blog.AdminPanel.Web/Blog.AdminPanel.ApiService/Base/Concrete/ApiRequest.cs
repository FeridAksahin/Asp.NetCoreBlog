using Blog.AdminPanel.ApiService.Base.Interface;
using Blog.AdminPanel.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AdminPanel.ApiService.Base.Concrete
{
    public class ApiRequest : IApiRequest
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiRequest(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<bool> PostAsync<T>(T data, string endpoint) where T : class
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_httpContextAccessor.HttpContext.Request.Cookies["jsonWebToken"]}");
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(endpoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<string> GetAsync(string userEmail, string userPassword, string endpoint) 
        {
            var response = await _client.GetAsync($"{endpoint}/{userEmail}/{userPassword}");
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }

        public async Task<string> PostAsyncResponseJson<T>(T data, string endpoint) where T : class
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_httpContextAccessor.HttpContext.Request.Cookies["jsonWebToken"]}");
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(endpoint, content);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<T> GetAsync<T>(string email, string endpoint) where T : class
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_httpContextAccessor.HttpContext.Request.Cookies["jsonWebToken"]}");
            var response = await _client.GetAsync($"{endpoint}/{email}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<string> PutAsync<T>(T data, string endpoint) where T : class
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_httpContextAccessor.HttpContext.Request.Cookies["jsonWebToken"]}");
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(endpoint, content);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<T>> GetAsyncList<T>(string userMail, string endpoint) where T : class
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_httpContextAccessor.HttpContext.Request.Cookies["jsonWebToken"]}");
            var response = await _client.GetAsync($"{endpoint}/{userMail}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<T>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            var response = await _client.DeleteAsync(endpoint);
            return response.IsSuccessStatusCode;
        }
    }
}
