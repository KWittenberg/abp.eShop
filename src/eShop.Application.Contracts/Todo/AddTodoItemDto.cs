using System;
using System.ComponentModel.DataAnnotations;

namespace eShop.Todo;

public class AddTodoItemDto
{
    [Required]
    public Guid TodoListId { get; set; }
    
    [Required]
    [StringLength(128)]
    public string Description { get; set; }
    public bool IsDone { get; set; }
}