using FluentValidation;

namespace eShop.Todo.Validator;

public class UpdateTodoItemDtoValidator : AbstractValidator<UpdateTodoItemDto>
{
    public UpdateTodoItemDtoValidator()
    {
        RuleFor(todoItem => todoItem.TodoListId).NotEmpty();
        RuleFor(todoItem => todoItem.Description).NotEmpty().MinimumLength(5).MaximumLength(64);
    }
}