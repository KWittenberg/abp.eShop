﻿namespace eShop.AppServices.Todo.Validator;

public class UpdateTodoItemDtoValidator : AbstractValidator<UpdateTodoItemDto>
{
    public UpdateTodoItemDtoValidator()
    {
        RuleFor(todoItem => todoItem.TodoListId).NotEmpty();
        RuleFor(todoItem => todoItem.Description).NotNull().MinimumLength(5).MaximumLength(64);
    }
}