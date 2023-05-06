using System;
using System.Collections.Generic;

namespace DataAccess
{
    public partial class Book
    {
        public Book()
        {
            BookProperties = new HashSet<BookProperty>();
            CartItems = new HashSet<CartItem>();
        }

        public int Isbn { get; set; }
        public string Category { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string PublishingHouse { get; set; } = null!;
        public int YearOfPublishing { get; set; }
        public int Pages { get; set; }
        public int AmountInStock { get; set; }
        public decimal Price { get; set; }
        public bool Deleted { get; set; }

        public virtual Category CategoryNavigation { get; set; } = null!;
        public virtual ICollection<BookProperty> BookProperties { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
