using eShop.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.EntityFrameworkCore.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog.Blog>
{
    public void Configure(EntityTypeBuilder<Blog.Blog> builder)
    {
        builder.ToTable("Blogs");
        builder.Property(x => x.Title).HasMaxLength(BlogConsts.MaxNameLength).IsRequired();
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired(true);
        builder.HasIndex(x => x.Title).IsUnique();
    }
}