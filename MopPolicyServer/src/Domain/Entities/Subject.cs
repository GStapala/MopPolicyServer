namespace MopPolicyServer.Domain.Entities;

public class Subject : BaseAuditableEntity 
{
    public string? Name { get; set; }
    public string? UserId { get; set; }
    public ICollection<PermissionSubject> PermissionSubjects { get; set; }
}
