using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Configurations
{
    public class SumaryPurchaseConfiguration : IEntityTypeConfiguration<PurchaseSummary>
    {
        public void Configure(EntityTypeBuilder<PurchaseSummary> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}