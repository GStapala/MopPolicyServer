namespace MopPolicyServer.Domain.Entities;

public class Role
{
    public int Id { get; set; }
    public int PolicyId { get; set; }
    public Policy Policy { get; set; }
    public string Name { get; set; }
    public ICollection<Subject> Subjects { get; set; }
    //public ICollection<string> IdentityRoles { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

}
