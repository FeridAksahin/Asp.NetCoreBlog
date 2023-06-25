using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AdminPanel.ApiService.Base.Interface
{
    public interface IApiRequest
    {
        public Task<bool> PostAsync<T>(T data, string endpoint) where T : class;
        public Task<string> GetAsync(string userEmail, string userPassword, string endpoint);
        public Task<string> PostAsyncResponseJson<T>(T data, string endpoint) where T : class;
        public Task<string> PutAsync<T>(T data, string endpoint) where T : class;
    }
}
