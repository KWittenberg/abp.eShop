namespace eShop.Web.Pages.Todo
{
    public class AddTodoListViewModel
    {
        //[SelectItems("Categories")]
        //[DisplayName("Category")]
        public Guid TodoListId { get; set; }

        [Required]
        [StringLength(TodoListConsts.MaxNameLength)]
        public string Title { get; set; }
    }
}