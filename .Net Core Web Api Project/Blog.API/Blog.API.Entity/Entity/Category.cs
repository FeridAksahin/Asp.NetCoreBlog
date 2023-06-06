using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.Entity.Entity
{
    public class Category : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public virtual IEnumerable<Article> Article { get; set; }
    }
}
