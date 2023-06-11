using Blog.BlogMaster.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BlogMaster.ApiService.Service.Interface
{
    public interface IUserService
    {
        public Task<AboutViewModel> GetAdminAbout(string username);
    }
}
