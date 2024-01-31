using MopPolicyServer.Domain.Entities;

namespace MopPolicyServer.Application.Common.Interfaces;

public interface IPolicyServerDbContext
{
    DbSet<Domain.Entities.Policy> Policies { get; set; }
    DbSet<Permission> Permissions { get; set; }
    DbSet<Subject> Subjects { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
