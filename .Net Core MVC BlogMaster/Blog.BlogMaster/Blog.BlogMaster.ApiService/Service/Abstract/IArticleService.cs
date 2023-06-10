using Blog.BlogMaster.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BlogMaster.ApiService.Service.Abstract
{
    public interface IArticleService
    {
        public Task<List<HomePageArticleViewModel>> GetAllArticleHeaderAndSubHeader();
        public Task<ArticleViewModel> GetArticlePost(int id);

    }
}
