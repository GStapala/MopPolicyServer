using MopPolicyServer.Application.Common.Interfaces;
using MopPolicyServer.Application.Common.Mappings;
using MopPolicyServer.Application.Common.Models;

namespace MopPolicyServer.Application.Policy.Queries.GetPolicyWithPagination;

public class GetPoliciesWithPaginationQuery: IRequest<PaginatedList<PolicyDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}


public class GetPoliciesWithPaginationQueryHandler(IPolicyServerDbContext context, IMapper mapper) : IRequestHandler<GetPoliciesWithPaginationQuery, PaginatedList<PolicyDto>>
{
    public async Task<PaginatedList<PolicyDto>> Handle(GetPoliciesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await context.Policies
            .OrderBy(x => x.Id)
            .ProjectTo<PolicyDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
