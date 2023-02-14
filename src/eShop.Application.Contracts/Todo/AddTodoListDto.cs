using System.ComponentModel.DataAnnotations;

namespace eShop.Todo;

public class AddTodoListDto
{
    [Required]
    [StringLength(128)]
    public string Title { get; set; }
}