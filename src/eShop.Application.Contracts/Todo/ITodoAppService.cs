using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace eShop.Todo;

public interface ITodoAppService : IApplicationService
{
    Task<List<TodoItemDto>> GetListAsync();
    Task<TodoItemDto> GetAsync(Guid id);
    Task<TodoItemDto> CreateAsync(AddTodoItemDto model);
    Task<TodoItemDto> UpdateAsync(Guid id, UpdateTodoItemDto model);
    Task DeleteAsync(Guid id);
}