﻿using System;
using System.Collections.Generic;
using System.Linq;
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

    // TODO: Implement the methods here...
    /// <summary>
    /// Get List
    /// </summary>
    /// <returns></returns>
    public async Task<List<TodoItemDto>> GetListAsync()
    {
        var items = await _todoItemRepository.GetListAsync();
        return items.Select(item => new TodoItemDto { Id = item.Id, Text = item.Text }).ToList();
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public async Task<TodoItemDto> CreateAsync(string text)
    {
        var todoItem = await _todoItemRepository.InsertAsync(new TodoItem { Text = text });
        return new TodoItemDto { Id = todoItem.Id, Text = todoItem.Text };
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