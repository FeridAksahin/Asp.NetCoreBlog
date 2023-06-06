using Blog.API.DataAccessLayer.Interface;
using Blog.API.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Blog.API.DataAccessLayer.Concrete;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = configuration.GetConnectionString("ConnectionStringForBlog");
builder.Services.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<BlogContext>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IArticleDal, ArticleDal>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
