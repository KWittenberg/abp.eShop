namespace eShop.EntityFrameworkCore.Configurations;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        builder.ToTable("TodoLists");
        builder.Property(x => x.Title).HasMaxLength(TodoListConsts.MaxNameLength).IsRequired();
        //builder.HasOne(x => x.User).WithMany(x => x.TodoItems).HasForeignKey(x => x.TodoListId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        //builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId); HAVE Error
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired(false);
        builder.HasMany(x => x.TodoItems).WithOne(x => x.TodoList).HasForeignKey(x => x.TodoListId);
        builder.HasIndex(x => x.Title).IsUnique();
    }
}