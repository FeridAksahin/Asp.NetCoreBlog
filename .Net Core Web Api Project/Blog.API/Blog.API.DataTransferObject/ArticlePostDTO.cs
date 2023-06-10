using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.DataTransferObject
{
    public class ArticlePostDTO
    {
        public string Text { get; set; }
        public string Category { get; set; }
        public HomePageArticleDTO ArticleSubInformation { get; set; }

    }
}
