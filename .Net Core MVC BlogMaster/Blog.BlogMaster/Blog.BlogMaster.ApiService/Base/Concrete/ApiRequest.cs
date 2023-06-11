
using Newtonsoft.Json;
using System.Text;

namespace Blog.BlogMaster.ApiService.Base.Concrete
{
    public class ApiRequest
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

        public async Task<List<T>> GetAsyncList<T>(string endpoint) where T : class
        {
            var response = await _client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var x = JsonConvert.DeserializeObject<List<T>>(await response.Content.ReadAsStringAsync());
                return x;
            }
            return null;
        }

        public async Task<T> GetAsync<T>(string endpoint, int id) where T : class
        {
            var response = await _client.GetAsync($"{endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<T> GetAsync<T>(string userMail, string endpoint) where T : class
        {
            var response = await _client.GetAsync($"{endpoint}/{userMail}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}
