using MopPolicyServer.Application.Common.Interfaces;

namespace MopPolicyServer.Application.Policy.Commands.DeletePolicy;

public record DeletePolicyCommand(int Id) : IRequest;

public class DeletePolicyCommandHandler(IPolicyServerDbContext context) : IRequestHandler<DeletePolicyCommand>
{
    public async Task Handle(DeletePolicyCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Policies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        context.Policies.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);
    }

}
