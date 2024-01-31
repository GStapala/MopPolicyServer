using MopPolicyServer.Application.Common.Interfaces;
using MopPolicyServer.Application.Common.Mappings;
using MopPolicyServer.Application.Common.Models;

namespace MopPolicyServer.Application.Policy.Queries.GetPolicyWithPagination;

public class GetPoliciesWithPaginationQuery: IRequest<PaginatedList<PolicyDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}


public class GetPoliciesWithPaginationQueryHandler : IRequestHandler<GetPoliciesWithPaginationQuery, PaginatedList<PolicyDto>>
{
    private readonly IPolicyServerDbContext  _context;
    private readonly IMapper _mapper;

    public GetPoliciesWithPaginationQueryHandler(IPolicyServerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PolicyDto>> Handle(GetPoliciesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Policies
            .OrderBy(x => x.Name)
            .ProjectTo<PolicyDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
