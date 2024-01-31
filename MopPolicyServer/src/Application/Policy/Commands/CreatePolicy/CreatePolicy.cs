using MopPolicyServer.Application.Common.Interfaces;

namespace MopPolicyServer.Application.Policy.Commands.CreatePolicy;

public record CreatePolicyCommand : IRequest<int>
{
    public string? Name { get; init; }

    public string? Description { get; init; }
}

public class CreatePolicyCommandHandler(IPolicyServerDbContext context) : IRequestHandler<CreatePolicyCommand, int>
{
    public async Task<int> Handle(CreatePolicyCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Policy { Name = request.Name, Description = request.Description };

        context.Policies.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
