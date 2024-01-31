namespace MopPolicyServer.Domain.Entities;

public class PermissionSubject : BaseAuditableEntity
{
    public int PermissionId { get; set; }
    public Permission? Permission { get; set; }
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }
}
