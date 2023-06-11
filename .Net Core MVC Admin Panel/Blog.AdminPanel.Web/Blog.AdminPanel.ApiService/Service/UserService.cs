using Blog.AdminPanel.ApiService.Base.Concrete;
using Blog.AdminPanel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AdminPanel.ApiService.Service
{
    public class UserService
    {
        private readonly ApiRequest _apiRequest;

        public UserService(ApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }

        public async Task<bool> AddNewAdmin(UserViewModel newAdmin)
        {
            return await _apiRequest.PostAsync<UserViewModel>(newAdmin, "User/AddAdminUser");
        }

        public async Task<bool> AdminLogin(UserViewModel user)
        {
            return await _apiRequest.GetAsync(user.Email,user.Password, "User/Login");
        }

        public async Task<string> AddAbout(AboutViewModel aboutModel)
        {
            return await _apiRequest.PostAsyncResponseJson(aboutModel, "User/AddAboutForAdmin");
        }

        public async Task<string> UpdateAbout(AboutViewModel aboutModel)
        {
            return await _apiRequest.PutAsync(aboutModel, "User/UpdateAboutForAdmin");
        }

        public async Task<AboutViewModel> GetAbout(string userMail)
        {
            return await _apiRequest.GetAsync<AboutViewModel>(userMail, "User/GetAbout");
        }
    }
}
