using Blog.AdminPanel.ApiService.Service;
using Blog.AdminPanel.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.AdminPanel.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleService _articleService;

        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddArticle(ArticleViewModel article)
        {
            if (ModelState.IsValid)
            {
                var result = await _articleService.AddNewArticle(article) ? "Added article." : "Request failed. Please try again.";
                return Json(new { data = result });
            }
            else
            {
                var error = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return Json(new { error = error });
            }
        }
    }
}
