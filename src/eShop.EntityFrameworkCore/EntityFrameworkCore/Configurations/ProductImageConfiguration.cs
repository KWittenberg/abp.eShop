namespace eShop.EntityFrameworkCore.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("ProductImages");
        builder.Property(x => x.Name).HasMaxLength(ProductImageConsts.MaxNameLength).IsRequired();
        builder.HasOne(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
    }
}