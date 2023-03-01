namespace eShop.AppServices.Todo.Validator;

public class UpdateTodoListDtoValidator : AbstractValidator<UpdateTodoListDto>
{
    public UpdateTodoListDtoValidator()
    {
        RuleFor(todoList => todoList.Title).NotNull().MinimumLength(3).MaximumLength(64);
    }
}