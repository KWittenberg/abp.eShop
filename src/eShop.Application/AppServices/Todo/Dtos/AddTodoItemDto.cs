namespace eShop.AppServices.Todo.Dtos;

public class AddTodoItemDto
{
    public Guid TodoListId { get; set; }

    public string Description { get; set; }
    
    public bool IsDone { get; set; } = false;
}