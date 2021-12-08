using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Configurations
{
    public class PurchaseItemConfiguration : IEntityTypeConfiguration<PurchaseItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Purchase)
                .WithMany(p => p.Products)
                .HasForeignKey(x => x.PurchaseId);

            builder
                .HasOne(x => x.Product)
                .WithMany(i => i.Purchases)
                .HasForeignKey(x => x.ProductId);
        }
    }
}