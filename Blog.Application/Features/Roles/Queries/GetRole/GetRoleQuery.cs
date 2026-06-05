using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Roles.Queries.GetRole
{
    public record GetRoleQuery(int Id) : IQuery<GetRoleQueryDto?>;
}
