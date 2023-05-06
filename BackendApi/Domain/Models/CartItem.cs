using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CartItem
    {
        public int CartId { get; set; }
        public int Isbn { get; set; }
        public int Amount { get; set; }
        public bool Deleted { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual Book IsbnNavigation { get; set; } = null!;
    }
}
