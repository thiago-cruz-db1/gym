using GymApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApi.Data.Data.ConfigModel;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .ToTable("products");
        
        builder
            .Property(a => a.Id)
            .HasColumnName("product_id");

        builder
            .Property(p => p.Price)
            .HasColumnName("product_price")
            .IsRequired();

        builder
            .Property(p => p.Name)
            .HasColumnName("product_name")
            .IsRequired();
        
        builder
            .Property<DateTime>("create_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
    }
}