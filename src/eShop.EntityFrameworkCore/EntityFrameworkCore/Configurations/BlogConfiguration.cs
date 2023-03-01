namespace eShop.EntityFrameworkCore.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs");
        builder.Property(x => x.Title).HasMaxLength(BlogConsts.MaxNameLength).IsRequired();
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired(true);
        builder.HasIndex(x => x.Title).IsUnique();
    }
}