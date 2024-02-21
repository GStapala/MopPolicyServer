using MopPolicyServer.Application.Common.Interfaces;

namespace MopPolicyServer.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdatePolicyCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

}

public class UpdatePolicyCommandHandler(IPolicyServerDbContext context) : IRequestHandler<UpdatePolicyCommand>
{
    public async Task Handle(UpdatePolicyCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Policies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;
        entity.Description = request.Description;

        await context.SaveChangesAsync(cancellationToken);
    }
}
