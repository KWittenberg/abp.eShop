using eShop.Products;
using eShop.Todo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.EntityFrameworkCore.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("TodoItems");
        builder.Property(x => x.Description).HasMaxLength(TodoItemConsts.MaxNameLength).IsRequired();
        builder.HasOne(x => x.TodoList).WithMany(x => x.TodoItems).HasForeignKey(x => x.TodoListId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        builder.HasIndex(x => x.Description).IsUnique();
    }
}