namespace MopPolicyServer.Domain.Entities;

public class Policy
{
    public Policy()
    {
        Created = DateTime.UtcNow;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Role> Roles { get; set; }
    public ICollection<Permission> Permissions { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}
