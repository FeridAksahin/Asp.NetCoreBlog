using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.DataTransferObject
{
    public class AboutDTO
    {
        public string AboutText { get; set; }
        public string? UserMail { get; set; }
    }
}
