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
                var userId = await _userDal.GetUserId(article.UserMail);
                _context.Article.Add(new Article
                {
                    Text = article.Text,
                    UserId = userId,
                    CategoryId = article.CategoryId,
                    Header = article.Header,
                    SubHeader = article.SubHeader,
                    CreatedBy = userId,
                    IsActive = true
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<HomePageArticleDTO>> GetArticleForHomePage()
        {
            try
            {
                var result = (from article in _context.Article
                              select new HomePageArticleDTO
                              {
                                  CreationDate = article.CreationDate,
                                  Header = article.Header,
                                  SubHeader = article.SubHeader,
                                  Username = article.User.Username,
                                  ArticleId = article.Id

                              }).ToList();
                return result;
            }
            catch
            {
                return null;
                throw;
            }
        }

        public async Task<ArticlePostDTO> GetArticlePost(int articleId)
        {
            try
            {
                return (from article in _context.Article
                        where article.Id == articleId
                        select new ArticlePostDTO
                        {
                            Category = article.Category.Name,
                            Text = article.Text,
                            ArticleSubInformation = new HomePageArticleDTO
                            {
                                ArticleId = article.Id,
                                CreationDate = article.CreationDate,    
                                Header = article.Header,
                                SubHeader = article.SubHeader,
                                Username = article.User.Username
                            }
                        }).FirstOrDefault();
            }
            catch
            {
                return null;
                throw;
            }
        }

        public async Task<List<ArticleDTO>> GetAllAdminArticle(string email)
        {
            return (from article in _context.Article
                    where article.User.Email.Equals(email) select new ArticleDTO
                    {
                        CategoryId = article.CategoryId,
                        Header = article.Header,
                        SubHeader = article.SubHeader,
                        Text = article.Text,
                        UserMail = article.User.Email,
                        ArticleId = article.Id
                    }).ToList();
        }

        public async Task<bool> DeleteArticle(int id)
        {
            try
            {
                var article = _context.Article.FirstOrDefault(x => x.Id == id);
                _context.Article.Remove(article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
                throw;
            }
        }
    }
}
