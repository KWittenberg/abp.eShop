namespace eShop.EntityFrameworkCore.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.Property(x => x.Name).HasMaxLength(CategoryConsts.MaxNameLength).IsRequired();
        builder.HasIndex(x => x.Name);


        //builder.ToTable(eShopConsts.DbTablePrefix + "Categories", eShopConsts.DbSchema);
        //builder.ConfigureByConvention();
        //builder.Property(x => x.Name).IsRequired().HasMaxLength(CategoryConsts.MaxNameLength);
        //builder.HasIndex(x => x.Name);

    }
}