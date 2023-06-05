using Blog.AdminPanel.ApiService.Base.Concrete;
using Blog.AdminPanel.ApiService.Service;
using Blog.AdminPanel.Validation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<BaseApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiAddress"]);
});
builder.Services.AddScoped<UserService>();
builder.Services.AddControllersWithViews()
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UserValidator>());
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
