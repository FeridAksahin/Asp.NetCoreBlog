using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.Entity.Entity
{
    [Table("Picture")]
    public class Picture : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

    }
}
