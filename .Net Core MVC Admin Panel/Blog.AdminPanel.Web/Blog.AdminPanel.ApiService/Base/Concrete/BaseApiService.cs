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
    public class BaseApiService : IBaseApiService
    {
        private readonly HttpClient _client;

        public BaseApiService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<bool> PostAsync<T>(T data, string endpoint) where T : class
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(endpoint, content).ConfigureAwait(false);
            //var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return response.IsSuccessStatusCode;  
        }
    }
}
