using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace eShop.Todo;

public class TodoList : AuditedAggregateRoot<Guid>
{
    public string Title { get; set; }
    public List<TodoItem> TodoItems { get; set; }


    // Add User
    public IdentityUser User { get; set; }
    public Guid UserId { get; set; }
}


