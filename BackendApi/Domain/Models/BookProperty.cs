using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class BookProperty
    {
        public int Isbn { get; set; }
        public string Attribute { get; set; } = null!;
        public object Value { get; set; } = null!;
        public bool Deleted { get; set; }

        public virtual Attribute AttributeNavigation { get; set; } = null!;
        public virtual Book IsbnNavigation { get; set; } = null!;
    }
}
