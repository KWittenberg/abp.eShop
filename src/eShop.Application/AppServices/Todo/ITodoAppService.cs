namespace eShop.AppServices.Todo;

public interface ITodoAppService : IApplicationService
{
    // TodoList
    Task<List<TodoListDto>> GetAllTodoListAsync();
    Task<TodoListDto> GetTodoListAsync(Guid todoListId);
    Task<TodoListDto> CreateTodoListAsync(AddTodoListDto model);
    Task<TodoListDto> UpdateTodoListAsync(Guid todoListId, UpdateTodoListDto model);
    Task DeleteTodoListAsync(Guid todoListId);

    // TodoItem
    Task<List<TodoItemDto>> GetAllTodoItemsInTodoListById(Guid todoListId);
    Task<TodoItemDto> GetTodoItemAsync(Guid todoItemId);
    Task<TodoItemDto> CreateTodoItemAsync(AddTodoItemDto model);
    Task<TodoItemDto> UpdateTodoItemAsync(Guid todoItemId, UpdateTodoItemDto model);
    Task DeleteTodoItemAsync(Guid todoItemId);
}