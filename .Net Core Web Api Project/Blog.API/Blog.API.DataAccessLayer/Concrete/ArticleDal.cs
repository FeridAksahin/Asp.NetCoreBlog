using Blog.API.DataAccessLayer.Interface;
using Blog.API.DataTransferObject;
using Blog.API.Entity.Context;
using Blog.API.Entity.Entity;

namespace Blog.API.DataAccessLayer.Concrete
{
    public class ArticleDal : IArticleDal
    {
        private readonly BlogContext _context;
        private readonly IUserDal _userDal;
        public ArticleDal(BlogContext context, IUserDal userDal)
        {
            _context = context;
            _userDal = userDal;
        }

        public async Task<bool> AddArticle(ArticleDTO article)
        {
                try
                {
                    _context.Article.Add(new Article
                    {
                        Text = article.Text,
                        UserId = await _userDal.GetUserId(article.UserMail),
                        CategoryId = article.CategoryId,
                        Header = article.Header,
                        SubHeader = article.SubHeader
                    });
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
        }
    }
}
