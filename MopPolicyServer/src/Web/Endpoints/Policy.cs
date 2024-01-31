using MopPolicyServer.Application.Common.Models;
using MopPolicyServer.Application.Policy.Commands.CreatePolicy;
using MopPolicyServer.Application.Policy.Commands.DeletePolicy;
using MopPolicyServer.Application.Policy.Queries.GetPolicyWithPagination;
using MopPolicyServer.Application.TodoItems.Commands.UpdateTodoItem;

namespace MopPolicyServer.Web.Endpoints;

public class Policy : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetPolicies)
            .MapPost(CreatePolicy)
            .MapDelete(DeletePolicy, "{id}")
            .MapPut(UpdatePolicy, "{id}")
            ;
    }

    public async Task<PaginatedList<PolicyDto>> GetPolicies(ISender sender, [AsParameters] GetPoliciesWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<int> CreatePolicy(ISender sender, CreatePolicyCommand command)
    {
        return await sender.Send(command);
    }
    
    public async Task<IResult> DeletePolicy(ISender sender, int id)
    {
        await sender.Send(new DeletePolicyCommand(id));
        return Results.NoContent();
    }  

    public async Task<IResult> UpdatePolicy(ISender sender, int id, UpdatePolicyCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
}
