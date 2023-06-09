using Microsoft.AspNetCore.Mvc;

namespace Blog.AdminPanel.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound()
        {
            return View("~/wwwroot/ErrorPage/404.cshtml");
        }
    }
}
