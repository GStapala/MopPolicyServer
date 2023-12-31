using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MopPolicyServer.Infrastructure.Data.Contexts.ContextInitializers;

public static class InitializerExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var applicationDbContextInitializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
        var policyServerDbContextInitializer = scope.ServiceProvider.GetRequiredService<PolicyServerDbContextInitializer>();

        await applicationDbContextInitializer.InitialiseAsync();
        await policyServerDbContextInitializer.InitialiseAsync();

        await applicationDbContextInitializer.SeedAsync();
        await policyServerDbContextInitializer.SeedAsync();
    }
}
