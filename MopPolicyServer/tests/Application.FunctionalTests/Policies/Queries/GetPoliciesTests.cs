using MopPolicyServer.Application.Policy.Queries.GetPolicyWithPagination;

namespace MopPolicyServer.Application.FunctionalTests.Policies.Queries;

using static Testing;

public class GetPoliciesTests : BaseTestFixture
{
    [Test]
    [TestCase("PolicyA")]
    public async Task ShouldReturnPolicies(string policyName)
    {
        await AddAsync(new Domain.Entities.Policy { Name = policyName });

        var query = new GetPoliciesWithPaginationQuery();

        var result = await SendAsync(query);

        result.Items.Should().HaveCount(1);
        result.Items.First().Name.Should().Be(policyName);
    }
}
