using Blog.API.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.DataAccessLayer.Interface
{
    public interface IArticleDal
    {
        public Task<bool> AddArticle(ArticleDTO article);
    }
}
