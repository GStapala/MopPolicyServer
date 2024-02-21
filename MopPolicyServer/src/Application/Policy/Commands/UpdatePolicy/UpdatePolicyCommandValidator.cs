namespace MopPolicyServer.Application.TodoItems.Commands.UpdateTodoItem;

public class UpdatePolicyCommandValidator : AbstractValidator<UpdatePolicyCommand>
{
    public UpdatePolicyCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotEmpty();
        
        RuleFor(v => v.Description)
            .MaximumLength(500)
            .NotEmpty();
    }
}
