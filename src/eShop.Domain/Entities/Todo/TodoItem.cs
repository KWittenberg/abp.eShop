namespace eShop.Entities.Todo;

public class TodoItem : AuditedAggregateRoot<Guid>
{
    public string Description { get; set; }
    
    public bool IsDone { get; set; }


    
    // Add TodoList
    public Guid TodoListId { get; set; }
    
    public TodoList TodoList { get; set; }
}