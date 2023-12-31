namespace MopPolicyServer.Domain.Entities;

public class PermissionSubject
{
    public int PermissionId { get; set; }
    public Permission Permission { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}
