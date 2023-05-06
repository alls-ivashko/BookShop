using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
            CategoryAttributes = new HashSet<CategoryAttribute>();
        }

        public string Name { get; set; } = null!;
        public bool Deleted { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<CategoryAttribute> CategoryAttributes { get; set; }
    }
}
