using Blog.BlogMaster.ApiService.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.BlogMaster.Ui.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _articleService.GetAllArticleHeaderAndSubHeader());
        }
        public async Task<IActionResult> Post(int id)
        {
            return View(await _articleService.GetArticlePost(id));
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
