using MopPolicyServer.Domain.Entities;

namespace MopPolicyServer.Application.Policy.Queries.GetPolicyWithPagination;

public class PolicyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Role> Roles { get; set; }
    public ICollection<Permission> Permissions { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Policy, PolicyDto>();
        }
    }
}
