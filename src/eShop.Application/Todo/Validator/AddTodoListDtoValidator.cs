using FluentValidation;    

namespace eShop.Todo.Validator;

public class AddTodoListDtoValidator : AbstractValidator<AddTodoListDto>
{
    public AddTodoListDtoValidator()
    {
        RuleFor(todoList => todoList.Title).NotEmpty().MinimumLength(5).MaximumLength(64);
    }
}