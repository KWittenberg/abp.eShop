using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace eShop.Todo;

public class TodoItem : AuditedAggregateRoot<Guid>
{
    public string Description { get; set; }
    public bool IsDone { get; set; }

    // Add TodoList
    public TodoList TodoList { get; set; }
    public Guid TodoListId { get; set; }
}