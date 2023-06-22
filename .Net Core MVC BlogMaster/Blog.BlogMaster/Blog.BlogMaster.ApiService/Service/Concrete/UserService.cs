using Blog.BlogMaster.ApiService.Base.Concrete;
using Blog.BlogMaster.ApiService.Service.Interface;
using Blog.BlogMaster.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BlogMaster.ApiService.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly ApiRequest _apiRequest;
        public UserService(ApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }

        public async Task<AboutViewModel> GetAdminAbout(string username)
        {
            return await _apiRequest.GetAsync<AboutViewModel>(username, "AdminFeature/GetAbout");
        }
    }
}
