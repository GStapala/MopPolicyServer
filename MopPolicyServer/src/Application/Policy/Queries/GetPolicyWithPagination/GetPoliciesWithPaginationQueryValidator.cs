﻿namespace MopPolicyServer.Application.Policy.Queries.GetPolicyWithPagination;

public class GetPoliciesWithPaginationQueryValidator : AbstractValidator<GetPoliciesWithPaginationQuery>
{
    public GetPoliciesWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
