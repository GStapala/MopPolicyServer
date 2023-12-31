namespace MopPolicyServer.Domain.Entities;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IdentityServerId { get; set; }
    public ICollection<PermissionSubject> PermissionSubjects { get; set; }
}
