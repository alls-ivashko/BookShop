using System;
using System.Collections.Generic;

namespace DataAccess
{
    public partial class CategoryAttribute
    {
        public string Category { get; set; } = null!;
        public string Attribute { get; set; } = null!;
        public bool Deleted { get; set; }

        public virtual Attribute AttributeNavigation { get; set; } = null!;
        public virtual Category CategoryNavigation { get; set; } = null!;
    }
}
