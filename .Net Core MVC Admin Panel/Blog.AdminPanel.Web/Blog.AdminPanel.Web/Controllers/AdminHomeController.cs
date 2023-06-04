using Microsoft.AspNetCore.Mvc;

namespace Blog.AdminPanel.Web.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
