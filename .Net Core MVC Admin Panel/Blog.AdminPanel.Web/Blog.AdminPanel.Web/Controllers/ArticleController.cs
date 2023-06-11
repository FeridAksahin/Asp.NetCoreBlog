using Blog.AdminPanel.ApiService.Service;
using Blog.AdminPanel.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.AdminPanel.Web.Controllers
{
    [Authorize]
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
            article.UserMail = User.FindFirstValue(ClaimTypes.Email);

            if (ModelState.IsValid)
            {
                var result = await _articleService.AddNewArticle(article) ? "Added article." : "Request failed. Please try again.";
                var icon = result.Equals("Request failed. Please try again.") ? "error" : "success";
                return Json(new { data = result, icon = icon });
            }
            else
            {
                var error = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return Json(new { data = error, icon = "error" });
            }
        }
    }
}
