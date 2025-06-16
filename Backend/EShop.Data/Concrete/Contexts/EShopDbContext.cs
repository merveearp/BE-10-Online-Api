using EShop.Data.Concrete.Configs;
using EShop.Data.Concrete.Extensions;
using EShop.Entity.Concrete;
using EShop.Shared.ComplexTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data.Concrete.Contexts
{
    public class EShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public EShopDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductCategory>? ProductCategories { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<CartItem>? CartItems { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedData();
            builder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
