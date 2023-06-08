using Blog.AdminPanel.ApiService.Service;
using Blog.AdminPanel.ViewModel;
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

        [HttpGet]
        public IActionResult Index()
        {
            TempData["Login"] = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel userViewModel)
        {

            TempData["Login"] = true;
            if (ModelState.IsValid)
            {
                if(userViewModel.Action.Equals("Register", StringComparison.OrdinalIgnoreCase) && await _userService.AddNewAdmin(userViewModel))
                {
                    return RedirectToAction("Index", "AdminHome");
                }
                else if(userViewModel.Action.Equals("Login", StringComparison.OrdinalIgnoreCase) && await _userService.AdminLogin(userViewModel))
                {
                    return RedirectToAction("Index", "AdminHome");
                }
                else
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ErrorPage", "404.html");
                    return PhysicalFile(filePath, "text/html");
                }
            }
            return View();
        }


    }
}
