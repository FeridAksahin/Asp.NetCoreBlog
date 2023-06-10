using Blog.BlogMaster.ApiService.Base.Concrete;
using Blog.BlogMaster.ApiService.Service.Abstract;
using Blog.BlogMaster.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.BlogMaster.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IActionResult Index()
        {
            var s = _articleService.GetAllArticleHeaderAndSubHeader();
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
