using MopPolicyServer.Application.Common.Extensions;
using MopPolicyServer.Domain.Entities;

namespace MopPolicyServer.Application.Policy.Queries.GetPolicyWithPagination;

public class PolicyDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    public string? Created { get; set; }
    public string? Updated { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Policy, PolicyDto>()
                .ForMember(x => x.Created, opt => opt.MapFrom(src => src.Created.ToShortDateTimeString()))
                .ForMember(x => x.Updated, opt => opt.MapFrom(src => src.LastModified.ToShortDateTimeString()));
        }
    }
}
