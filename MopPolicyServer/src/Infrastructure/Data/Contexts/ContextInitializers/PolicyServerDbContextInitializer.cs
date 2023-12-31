using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MopPolicyServer.Infrastructure.Data.Contexts.ContextInitializers;

public class PolicyServerDbContextInitializer
{
    private readonly ILogger<PolicyServerDbContextInitializer> _logger;
    private readonly PolicyServerDbContext _context;

    public PolicyServerDbContextInitializer(ILogger<PolicyServerDbContextInitializer> logger, PolicyServerDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
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
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        
    }
}
