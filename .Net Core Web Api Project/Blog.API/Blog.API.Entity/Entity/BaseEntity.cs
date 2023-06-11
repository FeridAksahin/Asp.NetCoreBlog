using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.Entity.Entity
{
    public class BaseEntity
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
