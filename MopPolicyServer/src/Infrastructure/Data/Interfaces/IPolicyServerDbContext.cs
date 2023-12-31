using Microsoft.EntityFrameworkCore;
using MopPolicyServer.Domain.Entities;

namespace MopPolicyServer.Infrastructure.Data.Interfaces;

public interface IPolicyServerDbContext
{
    DbSet<Policy> Policies { get; set; }
    DbSet<Permission> Permissions { get; set; }
    DbSet<Subject> Subjects { get; set; }
}
