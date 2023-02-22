using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace eShop.Todo;

public class TodoAppService : ApplicationService, ITodoAppService
{
    private readonly IRepository<TodoItem, Guid> _todoItemRepository;
    private readonly IRepository<TodoList, Guid> _todoListRepository;
    private readonly ICurrentUser _currentUser;

    public TodoAppService(IRepository<TodoItem, Guid> todoItemRepository, IRepository<TodoList, Guid> todoListRepository, ICurrentUser currentUser)
    {
        _todoItemRepository = todoItemRepository;
        _todoListRepository = todoListRepository;
        _currentUser = currentUser;
    }


    // TodoLists //////////////////////////////////////////////////////////
    /// <summary>
    /// GetAll TodoList
    /// </summary>
    /// <returns></returns>
    public async Task<List<TodoListDto>> GetAllTodoListAsync()
    {
        var userId = _currentUser.Id;
        var todoLists = await _todoListRepository.GetListAsync(x => x.UserId == userId);
        return ObjectMapper.Map<List<TodoList>, List<TodoListDto>>(todoLists);
    }

    /// <summary>
    /// Get TodoList
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<TodoListDto> GetTodoListAsync(Guid todoListId)
    {
        //var todoList = await _todoListRepository.FirstOrDefaultAsync(x => x.Id == Id);
        var todoList = await _todoListRepository.GetAsync(todoListId);
        return ObjectMapper.Map<TodoList, TodoListDto>(todoList);
    }

    /// <summary>
    /// Create TodoList
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public virtual async Task<TodoListDto> CreateTodoListAsync(AddTodoListDto model)
    {
        var userId = _currentUser.Id;
        if (userId is null) throw new EntryPointNotFoundException("User Not Found.");

        var todoList = new TodoList();
        ObjectMapper.Map(model, todoList);

        todoList.UserId = (Guid)userId;
        todoList = await _todoListRepository.InsertAsync(todoList);

        return ObjectMapper.Map<TodoList, TodoListDto>(todoList);
    }

    /// <summary>
    /// Update TodoList
    /// </summary>
    /// <param name="todoListId"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="EntryPointNotFoundException"></exception>
    public virtual async Task<TodoListDto> UpdateTodoListAsync(Guid todoListId, UpdateTodoListDto model)
    {
        var todoList = await _todoListRepository.GetAsync(todoListId);
        if (todoList is null) throw new EntryPointNotFoundException("TodoList Not Found.");
        ObjectMapper.Map(model, todoList);
        return ObjectMapper.Map<TodoList, TodoListDto>(todoList);
    }
    
    /// <summary>
    /// Delete TodoList
    /// </summary>
    /// <param name="todoItemId"></param>
    /// <returns></returns>
    public async Task DeleteTodoListAsync(Guid todoListId)
    {
        var todoList = await _todoListRepository.GetAsync(todoListId);
        if (todoList is null) throw new EntryPointNotFoundException("TodoList Not Found.");
        await _todoListRepository.DeleteAsync(todoList);
    }


    // TodoItems //////////////////////////////////////////////////////////
    /// <summary>
    /// Get All TodoItems In TodoList By TodoListId
    /// </summary>
    /// <param name="todoListId"></param>
    /// <returns></returns>
    public async Task<List<TodoItemDto>> GetAllTodoItemsInTodoListById(Guid todoListId)
    {
        var todoListItems = await _todoItemRepository.GetListAsync(x => x.TodoListId == todoListId);
        return ObjectMapper.Map<List<TodoItem>, List<TodoItemDto>>(todoListItems);
    }

    /// <summary>
    /// Get TodoItem
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TodoItemDto> GetTodoItemAsync(Guid todoItemId)
    {
        var todoItem = await _todoItemRepository.GetAsync(todoItemId);
        return ObjectMapper.Map<TodoItem, TodoItemDto>(todoItem);
    }

    /// <summary>
    /// Create TodoItem
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<TodoItemDto> CreateTodoItemAsync(AddTodoItemDto model)
    {
        var todoList = await _todoListRepository.FirstOrDefaultAsync(x => x.Id == model.TodoListId);
        if (todoList is null) throw new EntryPointNotFoundException("TodoList Not Found.");

        var todoItem = ObjectMapper.Map<AddTodoItemDto, TodoItem>(model);
        todoItem.TodoList = todoList;
        todoItem = await _todoItemRepository.InsertAsync(todoItem);
        return ObjectMapper.Map<TodoItem, TodoItemDto>(todoItem);
    }

    /// <summary>
    /// Update TodoItem
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<TodoItemDto> UpdateTodoItemAsync(Guid todoItemId, UpdateTodoItemDto model)
    {
        var todoItem = await _todoItemRepository.GetAsync(todoItemId);
        if (todoItem is null) throw new EntryPointNotFoundException("TodoItem Not Found.");
        ObjectMapper.Map(model, todoItem);
        return ObjectMapper.Map<TodoItem, TodoItemDto>(todoItem);
    }

    /// <summary>
    /// Delete TodoItem
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteTodoItemAsync(Guid todoItemId)
    {
        var todoItem = await _todoItemRepository.GetAsync(todoItemId);
        if (todoItem is null) throw new EntryPointNotFoundException("TodoItem Not Found.");
        await _todoItemRepository.DeleteAsync(todoItem);
    }
}