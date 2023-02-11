using System.ComponentModel.DataAnnotations;

namespace eShop.Todo;

public class AddTodoItemDto
{
    [Required]
    [StringLength(128)]
    public string Text { get; set; }
}