using Blog.BlogMaster.ApiService.Base.Concrete;
using Blog.BlogMaster.ApiService.Service.Abstract;
using Blog.BlogMaster.ApiService.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ApiRequest>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiAddress"]);
});

builder.Services.AddScoped<IArticleService, ArticleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
