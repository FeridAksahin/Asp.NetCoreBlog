using Blog.AdminPanel.ApiService.Service;
using Blog.AdminPanel.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.AdminPanel.Web.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly UserService _userService;
        public AdminHomeController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            TempData["Login"] = null;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> About()
        {
            return View(await _userService.GetAbout(User.FindFirstValue(ClaimTypes.Email)));
        }

        [HttpPost]
        public async Task<JsonResult> About(AboutViewModel aboutModel, string type)
        {
            string responseMessage;
            if (ModelState.IsValid)
            {
                aboutModel.UserMail = User.FindFirstValue(ClaimTypes.Email);
                if (type.Equals("Add", StringComparison.OrdinalIgnoreCase))
                {
                    responseMessage = await _userService.AddAbout(aboutModel);
                }
                else
                {
                    responseMessage = await _userService.UpdateAbout(aboutModel);
                }
            }
            else
            {
                responseMessage = "Model is not valid.";
            }

            return Json(responseMessage);
        }
    }
}
