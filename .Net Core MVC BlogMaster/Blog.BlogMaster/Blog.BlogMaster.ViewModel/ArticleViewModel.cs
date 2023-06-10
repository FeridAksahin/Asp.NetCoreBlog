using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BlogMaster.ViewModel
{
    public class ArticleViewModel
    {
        public string Text { get; set; }
        public string Category { get; set; }
        public HomePageArticleViewModel ArticleSubInformation { get; set; }
    }
}
