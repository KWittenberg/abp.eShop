namespace eShop.Web.Pages.Todo;

public class AddTodoListModalModel : eShopPageModel
{
    [BindProperty]
    public AddTodoListViewModel TodoList { get; set; }
    //public SelectListItem[] Categories { get; set; }

    private readonly ITodoAppService _todoAppService;

    public AddTodoListModalModel(ITodoAppService todoAppService)
    {
        _todoAppService = todoAppService;
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <returns></returns>
    public async Task OnGetAsync()
    {
        TodoList = new AddTodoListViewModel(); // { ReleaseDate = Clock.Now, StockState = TodoListStockState.PreOrder };
        //var categoryLookup = await _productAppService.GetCategoriesAsync();
        //Categories = categoryLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToArray();
    }

    /// <summary>
    /// Post
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> OnPostAsync()
    {
        await _todoAppService.CreateTodoListAsync(ObjectMapper.Map<AddTodoListViewModel, AddTodoListDto>(TodoList));
        return NoContent();
    }
}