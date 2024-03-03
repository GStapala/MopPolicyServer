using MopPolicyServer.Application.Policy.Commands.CreatePolicy;
using MopPolicyServer.Application.Common.Exceptions;

namespace MopPolicyServer.Application.FunctionalTests.Policies.Queries;

using static Testing;

public class CreatePolicyTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreatePolicyCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    
    [Test]
    public async Task ShouldCreatePolicy()
    {
        var userId = await GetUserFromExternalService();
        
        var command = new CreatePolicyCommand
        {
            Name = "New Policy",
            Description = "Policy Description"
        };

        var policyId = await SendAsync(command);

        var item = await FindAsync<Domain.Entities.Policy>(policyId);

        item.Should().NotBeNull();
        item!.Name.Should().Be(command.Name);
        item.Description.Should().Be(command.Description);
        item.CreatedBy.Should().Be(userId);
        item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
