using MopPolicyServer.Application.Common.Models;
using MopPolicyServer.Application.Policy.Queries.GetPolicyWithPagination;

namespace MopPolicyServer.Web.Endpoints;

public class Policy : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetPolicies)
            ;
    }

    public async Task<PaginatedList<PolicyDto>> GetPolicies(ISender sender, [AsParameters] GetPoliciesWithPaginationQuery query)
    {
        return await sender.Send(query);
    }

}
