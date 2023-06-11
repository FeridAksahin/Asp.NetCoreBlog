using Blog.API.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Entity.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<AdminUserAbout> AdminUserAbout { get; set; }
    }
}