using eShop.Todo;
using System.Collections.Generic;

namespace eShop.Web.Pages.Todo;

public class TodoItems : eShopPageModel
{
    public List<TodoItemDto> TodoItem { get; set; }
    public Guid todoListId { get; private set; }

    private readonly ITodoAppService _todoAppService;

    public TodoItems(ITodoAppService todoAppService)
    {
        _todoAppService = todoAppService;
    }

    public async Task OnGetAsync()
    {
        TodoItem = await _todoAppService.GetAllTodoItemsInTodoListById(todoListId);
    }
}