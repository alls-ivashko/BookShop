using System;
using System.Collections.Generic;

namespace DataAccess
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public string CustomerLogin { get; set; } = null!;
        public bool Deleted { get; set; }

        public virtual Customer CustomerLoginNavigation { get; set; } = null!;
        public virtual OrderDetail? OrderDetail { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
