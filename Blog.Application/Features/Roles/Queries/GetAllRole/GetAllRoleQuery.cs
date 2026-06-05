using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Roles.Queries.GetAllRole
{
    public record GetAllRoleQuery() : IQuery<List<GetAllRoleQueryDto>>;
}
