using Blog.AdminPanel.ApiService.Base.Interface;
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

        public ApiRequest(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<bool> PostAsync<T>(T data, string endpoint) where T : class
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(endpoint, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> GetAsync(string userEmail, string userPassword, string endpoint)
        {
            var response = await _client.GetAsync($"{endpoint}/{userEmail}/{userPassword}");
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return Convert.ToBoolean(responseContent);
        }
    }
}
