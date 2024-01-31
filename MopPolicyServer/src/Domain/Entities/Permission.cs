namespace MopPolicyServer.Domain.Entities;

public class Permission : BaseAuditableEntity
{
    public int PolicyId { get; set; }
    public Policy Policy { get; set; }
    public string? Name { get; set; }
    //public ICollection<Role<TUserKey>> Roles { get; set; } 
    public ICollection<PermissionSubject> PermissionSubjects { get; set; }
    public string? Description { get; set; }
}
