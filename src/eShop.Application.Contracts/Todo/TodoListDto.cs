using System;
using System.Collections.Generic;

namespace eShop.Todo;

public class TodoListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }


    // Add User
    public Guid UserId { get; set; }
    
    
    // Add Items
    public List<TodoItemDto> TodoItems { get; set; }

    public DateTime CreationTime { get; set; }
    public DateTime LastModificationTime { get; set; }
}