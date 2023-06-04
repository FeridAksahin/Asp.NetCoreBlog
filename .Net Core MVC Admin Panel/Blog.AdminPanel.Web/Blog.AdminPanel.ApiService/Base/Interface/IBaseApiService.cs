using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AdminPanel.ApiService.Base.Interface
{
    public interface IBaseApiService
    {
        Task<bool> PostAsync<T>(T data, string endpoint) where T : class;
    }
}
