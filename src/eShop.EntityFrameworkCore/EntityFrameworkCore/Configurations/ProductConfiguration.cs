namespace eShop.EntityFrameworkCore.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.Property(x => x.Name).HasMaxLength(ProductConsts.MaxNameLength).IsRequired();
        builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
    }
}