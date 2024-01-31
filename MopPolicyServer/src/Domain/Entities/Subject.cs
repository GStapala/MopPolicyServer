namespace MopPolicyServer.Domain.Entities;

public class Subject : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? IdentityServerId { get; set; }
    public ICollection<PermissionSubject> PermissionSubjects { get; set; }
}
