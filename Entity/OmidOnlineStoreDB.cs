using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OmidOnlineStoreDB:IdentityDbContext<ApplicationUser>
    {

        public OmidOnlineStoreDB(DbContextOptions options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Blog>().ToTable("Blogs");
            modelBuilder.Entity<Order>().ToTable("Orders");

            modelBuilder.Entity<Cart>()
                .HasOne(x => x.User)
                .WithOne(x => x.Cart)
                .HasForeignKey<Cart>(x => x.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<CartItem>().ToTable("CartItems");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
        }

    }
}
