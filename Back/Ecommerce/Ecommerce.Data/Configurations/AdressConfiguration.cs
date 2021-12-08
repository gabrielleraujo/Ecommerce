using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.Configurations
{
    public class AdressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasData(new Address
            {
                Id = 1,
                CEP = "26053330",
                Number = 10,
                Complement = "House",
                Neighborhood = "Vila de Cava",
                City = "Nova Iguaçu",
                State = "RJ"
            });
        }
    }
}