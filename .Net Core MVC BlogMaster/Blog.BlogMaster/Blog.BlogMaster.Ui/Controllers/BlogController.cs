using Blog.BlogMaster.ApiService.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Blog.BlogMaster.Ui.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;

        public BlogController(IArticleService articleService, IUserService userService)
        {
            _articleService = articleService;
            _userService = userService; 
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
        public async Task<IActionResult> About(string username)
        {
            if(username != null)
            {
                var adminAbout = await _userService.GetAdminAbout(username);
                adminAbout.Username = username;
                return View(adminAbout);
            }
            else
            {
                return View();
            }
   
        }
    }
}
