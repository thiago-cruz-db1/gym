using Gym.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataContext
{
    public class ProductConfig : IEntityTypeConfiguration<GymStoreProduct>
    {
        public void Configure(EntityTypeBuilder<GymStoreProduct> builder)
        {
            builder
                .ToTable("gym_product");

            builder
                .Property(x => x.Id)
                .HasColumnName("product_id")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasColumnName("product_name")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(x => x.Quantity)
                .HasColumnName("product_quantity")
                .HasColumnType("number")
                .IsRequired();

            builder
                .Property(x => x.Price)
                .HasColumnName("product_price")
                .HasColumnType("decimal")
                .IsRequired();

            builder
                .Property(x => x.Stored)
                .HasColumnName("product_storage")
                .HasColumnType("varchar(45)")
                .IsRequired();
        }
    }
}
