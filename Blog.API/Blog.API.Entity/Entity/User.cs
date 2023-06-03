using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.Entity.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Username { get; set; }
        [StringLength(70)]
        public string Email { get; set; }
        [StringLength(30)]
        public string Password { get; set; }    
        public virtual List<Article> Article { get; set; }
    }
}
