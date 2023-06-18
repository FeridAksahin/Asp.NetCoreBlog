using Blog.AdminPanel.ApiService.Base.Concrete;
using Blog.AdminPanel.ViewModel;

namespace Blog.AdminPanel.ApiService.Service
{
    public class ArticleService
    {
        private readonly ApiRequest _apiRequest;

        public ArticleService(ApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }

        public async Task<bool> AddNewArticle(ArticleViewModel article)
        {
            return await _apiRequest.PostAsync<ArticleViewModel>(article, "Article/AddArticle");
        }

        public async Task<List<ArticleViewModel>> GetAllArticle(string userMail)
        {
            return await _apiRequest.GetAsyncList<ArticleViewModel>(userMail, "Article/AllAddedArticle");
        }

        public async Task<bool> DeleteArticle(int id)
        {
            return await _apiRequest.DeleteAsync($"Article/DeleteArticleById/{id}");
        }

    }
}
