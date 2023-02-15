using FluentValidation;

namespace eShop.Todo.Validator;

public class AddTodoItemDtoValidator : AbstractValidator<AddTodoItemDto>
{
    public AddTodoItemDtoValidator()
    {
        RuleFor(todoItem => todoItem.TodoListId).NotEmpty();
        RuleFor(todoItem => todoItem.Description).NotEmpty().MinimumLength(5).MaximumLength(64);
    }
}