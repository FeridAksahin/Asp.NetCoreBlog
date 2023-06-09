using Blog.AdminPanel.ApiService.Base.Concrete;
using Blog.AdminPanel.ApiService.Service;
using Blog.AdminPanel.Validation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ApiRequest>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiAddress"]);
});
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ArticleService>();
builder.Services.AddControllersWithViews()
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UserValidator>());

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "Admin.Panel.Authentication";
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/Error/NotFound";   
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
});

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
