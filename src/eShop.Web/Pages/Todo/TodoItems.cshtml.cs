namespace eShop.Web.Pages.Todo;

public class TodoItems : eShopPageModel
{
    public List<TodoItemDto> TodoItem { get; set; }
    public Guid TodoListId { get; set; }

    private readonly ITodoAppService _todoAppService;

    public TodoItems(ITodoAppService todoAppService)
    {
        _todoAppService = todoAppService;
    }

    public async Task OnGetAsync(Guid Id)
    {
        TodoItem = await _todoAppService.GetAllTodoItemsInTodoListById(Id);
    }
}