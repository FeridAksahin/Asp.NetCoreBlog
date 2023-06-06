using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.DataTransferObject
{
    public class ArticleDTO
    {
        public string Header { get; set; }
        public string? SubHeader { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
