using Microsoft.EntityFrameworkCore;
using MopPolicyServer.Application.Common.Interfaces;
using MopPolicyServer.Domain.Entities;

namespace MopPolicyServer.Infrastructure.Data.Contexts;

public class PolicyServerDbContext : DbContext, IPolicyServerDbContext
{
    private const string SchemaName = "pol";

    // dotnet ef migrations add "InitialPolicyServerMigration" --project src\Infrastructure --startup-project src\Web --output-dir Data\Migrations --context PolicyServerDbContext
    public PolicyServerDbContext(DbContextOptions<PolicyServerDbContext> options) : base(options)
    {
    }

    public DbSet<Policy> Policies { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ConfigurePolicyContext(builder);
        
        base.OnModelCreating(builder);
    }

    private void ConfigurePolicyContext(ModelBuilder builder)
    {
        // many-to-many
        builder.Entity<PermissionSubject>(builder =>
        {
            builder.Metadata.SetSchema(SchemaName);
            builder.HasKey(ps => new { ps.PermissionId, ps.SubjectId });
            builder.HasOne(ps => ps.Subject).WithMany(p => p.PermissionSubjects).HasForeignKey(ps => ps.SubjectId);
            builder.HasOne(ps => ps.Permission).WithMany(p => p.PermissionSubjects).HasForeignKey(ps => ps.PermissionId);
        });

        builder.Entity<Policy>(builder =>
        {
            builder.ToTable("Policies", SchemaName);
            builder.HasKey(x => x.Id);
        });

        builder.Entity<Permission>(builder =>
        {
            builder.ToTable("Permissions", SchemaName);
            builder.HasKey(x => x.Id);
        });

        builder.Entity<Role>(builder =>
        {
            builder.ToTable("Roles", SchemaName);
            builder.HasKey(x => x.Id);
        });
        builder.Entity<Subject>(builder =>
        {
            builder.ToTable("Subjects", SchemaName);
            builder.HasKey(x => x.Id);
        });
    }
}
