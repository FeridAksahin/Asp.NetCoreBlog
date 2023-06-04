using Blog.AdminPanel.ApiService.Service;
using Microsoft.AspNetCore.Mvc;

namespace Blog.AdminPanel.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            //test for api method communication
            Task<bool> task = _userService.AddNewAdmin(new ViewModel.UserViewModel { Email = "g", Password = "garg", Username = "gtsh" });
            var result = await task;
            return View();
        }
    }
}
