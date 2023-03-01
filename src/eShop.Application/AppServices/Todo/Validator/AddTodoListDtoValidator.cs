namespace eShop.AppServices.Todo.Validator;

public class AddTodoListDtoValidator : AbstractValidator<AddTodoListDto>
{
    public AddTodoListDtoValidator()
    {
        RuleFor(todoList => todoList.Title).NotNull().MinimumLength(3).MaximumLength(64);
    }
}