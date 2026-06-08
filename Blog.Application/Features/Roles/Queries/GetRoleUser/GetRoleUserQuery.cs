using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Roles.Queries.GetRoleUser
{
    public record GetRoleUserQuery(int UserId) : IQuery<List<GetRoleUserQueryDto>>;
}
