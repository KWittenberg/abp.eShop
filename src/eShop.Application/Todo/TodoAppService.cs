using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace eShop.Todo;

public class TodoAppService : ApplicationService, ITodoAppService
{
    private readonly IRepository<TodoItem, Guid> _todoItemRepository;

    public TodoAppService(IRepository<TodoItem, Guid> todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    /// <summary>
    /// Get List
    /// </summary>
    /// <returns></returns>
    public async Task<List<TodoItemDto>> GetListAsync()
    {
        var items = await _todoItemRepository.GetListAsync();
        return ObjectMapper.Map<List<TodoItem>, List<TodoItemDto>>(items);
    }

    /// <summary>
    /// Get Todo List by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TodoItemDto> GetAsync(Guid id)
    {
        var todoItem = await _todoItemRepository.GetAsync(id);
        return ObjectMapper.Map<TodoItem, TodoItemDto>(todoItem);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<TodoItemDto> CreateAsync(AddTodoItemDto model)
    {
        var todoItem = new TodoItem();
        ObjectMapper.Map(model, todoItem);
        todoItem = await _todoItemRepository.InsertAsync(todoItem);
        return ObjectMapper.Map<TodoItem, TodoItemDto>(todoItem);
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<TodoItemDto> UpdateAsync(Guid id, UpdateTodoItemDto model)
    {
        var todoItem = await _todoItemRepository.GetAsync(id);
        ObjectMapper.Map(model, todoItem);
        return ObjectMapper.Map<TodoItem, TodoItemDto>(todoItem);
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAsync(Guid id)
    {
        await _todoItemRepository.DeleteAsync(id);
    }
}