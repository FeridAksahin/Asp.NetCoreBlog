using Microsoft.AspNetCore.Mvc;

namespace Blog.BlogMaster.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult AboutMe()
        {
            return View();
        }
    }
}
