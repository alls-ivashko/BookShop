using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class BookShopContext : DbContext
    {
        public BookShopContext()
        {
        }

        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookProperty> BookProperties { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategoryAttribute> CategoryAttributes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Attribut__737584F7B7F801E8");

                entity.ToTable("Attribute");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__Book__447D36EBAF1130BD");

                entity.ToTable("Book");

                entity.Property(e => e.Isbn)
                    .ValueGeneratedNever()
                    .HasColumnName("ISBN");

                entity.Property(e => e.AmountInStock).HasColumnName("Amount_in_stock");

                entity.Property(e => e.Author)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.PublishingHouse)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Publishing_house");

                entity.Property(e => e.YearOfPublishing).HasColumnName("Year_of_publishing");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book__Category__2E1BDC42");
            });

            modelBuilder.Entity<BookProperty>(entity =>
            {
                entity.HasKey(e => new { e.Isbn, e.Attribute })
                    .HasName("PK__Book_pro__7BF95C7095C754B0");

                entity.ToTable("Book_property");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.Attribute)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("sql_variant");

                entity.HasOne(d => d.AttributeNavigation)
                    .WithMany(p => p.BookProperties)
                    .HasForeignKey(d => d.Attribute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book_prop__Attri__37A5467C");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.BookProperties)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book_prope__ISBN__36B12243");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerLogin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Customer_login");

                entity.HasOne(d => d.CustomerLoginNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__Customer_l__3B75D760");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.Isbn })
                    .HasName("PK__Cart_ite__72C1FCAF6CCEC9DA");

                entity.ToTable("Cart_item");

                entity.Property(e => e.CartId).HasColumnName("Cart_id");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_item__Cart___3F466844");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_item__ISBN__403A8C7D");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Category__737584F7CB1D4698");

                entity.ToTable("Category");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryAttribute>(entity =>
            {
                entity.HasKey(e => new { e.Category, e.Attribute })
                    .HasName("PK__Category__743356A85D5E6B2E");

                entity.ToTable("Category_attribute");

                entity.Property(e => e.Category)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Attribute)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AttributeNavigation)
                    .WithMany(p => p.CategoryAttributes)
                    .HasForeignKey(d => d.Attribute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category___Attri__32E0915F");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.CategoryAttributes)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Category___Categ__31EC6D26");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("PK__Customer__5E55825A8DC76854");

                entity.ToTable("Customer");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("First_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Middle_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Phone_number")
                    .IsFixedLength();

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode).HasColumnName("Zip_code");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Order_de__D6862FC1EF0FF920");

                entity.ToTable("Order_details");

                entity.Property(e => e.CartId)
                    .ValueGeneratedNever()
                    .HasColumnName("Cart_id");

                entity.Property(e => e.CompletionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Completion_time");

                entity.Property(e => e.DeliveryCity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Delivery_city");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("date")
                    .HasColumnName("Delivery_date");

                entity.Property(e => e.DeliveryFlat).HasColumnName("Delivery_flat");

                entity.Property(e => e.DeliveryHouse).HasColumnName("Delivery_house");

                entity.Property(e => e.DeliveryPrice)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("Delivery_price");

                entity.Property(e => e.DeliveryRegion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Delivery_region");

                entity.Property(e => e.DeliveryStreet)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Delivery_street");

                entity.Property(e => e.DeliveryZipCode).HasColumnName("Delivery_zip_code");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Payment_type");

                entity.Property(e => e.RegistrationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Registration_time");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cart)
                    .WithOne(p => p.OrderDetail)
                    .HasForeignKey<OrderDetail>(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_det__Cart___440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
