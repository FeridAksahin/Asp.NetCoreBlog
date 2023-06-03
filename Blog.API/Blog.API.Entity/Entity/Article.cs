using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.Entity.Entity
{
    [Table("Article")]
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Header { get; set; }
        public string? SubHeader { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual List<Picture> Picture { get; set; }

    }
}
