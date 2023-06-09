﻿using Blog.AdminPanel.ApiService.Service;
using Blog.AdminPanel.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.AdminPanel.Web.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(UserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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
                if (userViewModel.Action.Equals("Register", StringComparison.OrdinalIgnoreCase) && await _userService.AddNewAdmin(userViewModel))
                {
                    return RedirectToAction("Index", "AdminHome");
                }
                else if (userViewModel.Action.Equals("Login", StringComparison.OrdinalIgnoreCase))
                {
                    var token = await _userService.AdminLogin(userViewModel);

                    if (string.IsNullOrEmpty(token))
                    {
                        throw new ArgumentNullException();
                    }

                    HttpContext httpContext = _httpContextAccessor.HttpContext;
                    CookieOptions options = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    };
                    httpContext.Response.Cookies.Append("jsonWebToken", token, options);

                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, userViewModel.Email)
                    };
                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);
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
