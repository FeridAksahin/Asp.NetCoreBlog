using Blog.BlogMaster.ApiService.Base.Concrete;
using Blog.BlogMaster.ApiService.Service.Abstract;
using Blog.BlogMaster.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BlogMaster.ApiService.Service.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly ApiRequest _apiRequest;

        public ArticleService(ApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }

        public async Task<List<HomePageArticleViewModel>> GetAllArticleHeaderAndSubHeader()
        {
            return await _apiRequest.GetAsyncList<HomePageArticleViewModel>("Article/GetArticleInformationForHomePage");
        }

        public async Task<ArticleViewModel> GetArticlePost(int id)
        {
            return await _apiRequest.GetAsync<ArticleViewModel>("Article/GetArticlePost", id);
        }
    }
}
