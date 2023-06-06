using Blog.API.DataAccessLayer.Interface;
using Blog.API.DataTransferObject;
using Blog.API.Entity.Context;
using Blog.API.Entity.Entity;

namespace Blog.API.DataAccessLayer.Concrete
{
    public class ArticleDal : IArticleDal
    {
        private readonly BlogContext _context;
        public ArticleDal(BlogContext context)
        {
            _context = context;
        }

        public async Task<bool> AddArticle(ArticleDTO article)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Article.Add(new Article
                    {
                        Text = article.Text,
                        UserId = article.UserId,
                        CategoryId = article.CategoryId,
                        Header = article.Header,
                        SubHeader = article.SubHeader
                    });
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
