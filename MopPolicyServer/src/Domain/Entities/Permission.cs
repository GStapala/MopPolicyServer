namespace MopPolicyServer.Domain.Entities;

public class Permission
{
    public Permission()
    {
        Created = DateTime.UtcNow;
    }

    public int Id { get; set; }
    public int PolicyId { get; set; }
    public Policy Policy { get; set; }
    public string Name { get; set; }
    //public ICollection<Role<TUserKey>> Roles { get; set; } 
    public ICollection<PermissionSubject> PermissionSubjects { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}
