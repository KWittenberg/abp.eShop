namespace eShop.Web.Pages.Todo;

public class IndexModel : eShopPageModel
{
    public List<TodoListDto> TodoLists { get; set; }

    private readonly ITodoAppService _todoAppService;

    public IndexModel(ITodoAppService todoAppService)
    {
        _todoAppService = todoAppService;
    }

    public async Task OnGetAsync()
    {
        TodoLists = await _todoAppService.GetAllTodoListAsync();
    }
}



//public class IndexModel : eShopPageModel
//{
//    public List<TodoItemDto> TodoItems { get; set; }

//    private readonly ITodoAppService _todoAppService;

//    public IndexModel(ITodoAppService todoAppService)
//    {
//        _todoAppService = todoAppService;
//    }

//    public async Task OnGetAsync()
//    {
//        TodoItems = await _todoAppService.GetAllTodoItemAsync();
//    }
//}