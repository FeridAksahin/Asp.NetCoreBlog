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
        private readonly BaseApiService _baseApiService;

        public UserService(BaseApiService baseApiService)
        {
            _baseApiService = baseApiService;
        }
        public async Task<bool> AddNewAdmin(UserViewModel newAdmin)
        {
            return await _baseApiService.PostAsync<UserViewModel>(newAdmin, "User/AddAdminUser");
        }
    }
}
