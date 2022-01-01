using Ecommerce.Data.Configurations;
using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchasesItems { get; set; }
        public DbSet<PurchaseSummary> SummariesPurchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AdressConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseItemConfiguration());
            modelBuilder.ApplyConfiguration(new SumaryPurchaseConfiguration());
        }
    }
}