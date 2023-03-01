namespace eShop.Common.Dtos;

public class TodoItemDto
{
    // Add TodoListId
    public Guid TodoListId { get; set; }


    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }


    public DateTime CreationTime { get; set; }
    public DateTime LastModificationTime { get; set; }
}