namespace MopPolicyServer.Domain.Entities;

public class Policy : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
