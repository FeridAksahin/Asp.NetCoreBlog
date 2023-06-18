using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AdminPanel.ViewModel
{
    public class ArticleViewModel
    {
        public string Header { get; set; }
        public string? SubHeader { get; set; }
        public string Text { get; set; }
        public string? UserMail { get; set; }
        public int CategoryId { get; set; }
        public int ArticleId { get; set; }
    }
}
