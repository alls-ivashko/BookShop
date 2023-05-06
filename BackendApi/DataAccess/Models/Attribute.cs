using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            BookProperties = new HashSet<BookProperty>();
            CategoryAttributes = new HashSet<CategoryAttribute>();
        }

        public string Name { get; set; } = null!;
        public bool Deleted { get; set; }

        public virtual ICollection<BookProperty> BookProperties { get; set; }
        public virtual ICollection<CategoryAttribute> CategoryAttributes { get; set; }
    }
}
