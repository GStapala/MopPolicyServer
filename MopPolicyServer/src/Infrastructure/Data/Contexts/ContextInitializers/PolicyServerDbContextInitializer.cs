using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MopPolicyServer.Infrastructure.Data.Contexts.ContextInitializers;

public class PolicyServerDbContextInitializer(ILogger<PolicyServerDbContextInitializer> logger, PolicyServerDbContext context)
{
    public async Task InitialiseAsync()
    {
        try
        {
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        //TODO example seeding
    }
}
