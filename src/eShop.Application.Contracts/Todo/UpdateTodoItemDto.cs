using System.ComponentModel.DataAnnotations;

namespace eShop.Todo;

public class UpdateTodoItemDto
{
    [Required]
    [StringLength(128)]
    public string Text { get; set; }
}