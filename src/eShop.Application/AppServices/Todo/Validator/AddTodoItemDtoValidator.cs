﻿namespace eShop.AppServices.Todo.Validator;

public class AddTodoItemDtoValidator : AbstractValidator<AddTodoItemDto>
{
    public AddTodoItemDtoValidator()
    {
        RuleFor(todoItem => todoItem.TodoListId).NotEmpty();
        RuleFor(todoItem => todoItem.Description).NotNull().MinimumLength(5).MaximumLength(64);
    }
}