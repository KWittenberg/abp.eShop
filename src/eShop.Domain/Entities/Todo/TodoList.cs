namespace eShop.Entities.Todo;

public class TodoList : AuditedAggregateRoot<Guid>
{
    public string Title { get; set; }

    public List<TodoItem> TodoItems { get; set; }



    // Add User
    public Guid UserId { get; set; }

    public IdentityUser User { get; set; }



    // konstruktor općenito u Create, a set u Update 
    public TodoList(Guid userId, string title)
    {
        UserId = userId;
        SetTitle(title);

        TodoItems = new List<TodoItem>();
    }

    // u slučaju MongoDB ili sličnog zbog skalabilnosti
    public TodoList(Guid id, Guid userId, string title) : this(userId, title)    {
        Id = id;
    }

    public TodoList()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    // Seter za Title
    public void SetTitle(string title)
    {
        Title = title;
    }
}