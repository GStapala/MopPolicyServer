namespace MopPolicyServer.Application.Policy.Commands.CreatePolicy;

public class CreatePolicyCommandValidator : AbstractValidator<CreatePolicyCommand>
{
    public CreatePolicyCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotEmpty();
        
        RuleFor(v => v.Description)
            .MaximumLength(500)
            .NotEmpty();
    }
}
