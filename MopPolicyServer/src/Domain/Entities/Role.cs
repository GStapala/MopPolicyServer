namespace MopPolicyServer.Domain.Entities;

public class Role : BaseAuditableEntity
{
    public int PolicyId { get; set; }
    public Policy Policy { get; set; }
    public string? Name { get; set; }

    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    //public ICollection<string> IdentityRoles { get; set; }
    public string? Description { get; set; }

}
