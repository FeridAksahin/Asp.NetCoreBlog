using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BlogMaster.ViewModel
{
    public class HomePageArticleViewModel
    {
        public string? Header { get; set; }
        public string? SubHeader { get; set; }
        public string? Username { get; set; }
        public DateTime? CreationDate { get; set; }
        public int ArticleId { get; set; }
    }
}
