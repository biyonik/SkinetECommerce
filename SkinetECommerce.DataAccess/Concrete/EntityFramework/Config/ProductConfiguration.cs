using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SkinetECommerce.DataAccess.Concrete.EntityFramework.Config;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.Property(p => p.PictureUrl).IsRequired();
        
        builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
        builder.HasOne(pt => pt.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
    }
}