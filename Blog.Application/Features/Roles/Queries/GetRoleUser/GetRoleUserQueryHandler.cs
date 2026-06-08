using Blog.Application.Interfaces.Repository;
using Blog.Domain.Entity;
using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Roles.Queries.GetRoleUser
{
    internal sealed class GetRoleUserQueryHandler(IRoleRepository roleRepository) : IQueryHandler<GetRoleUserQuery, List<GetRoleUserQueryDto>>
    {
        public async Task<List<GetRoleUserQueryDto>> HandleAsync(GetRoleUserQuery message, CancellationToken cancellationToken = default)
        {
            List<RoleEntity> roles = await roleRepository.GetRoleByUserIdAsync(message.UserId, cancellationToken);
            return roles.Select(r => new GetRoleUserQueryDto(r.Id, r.Description, r.CreatedAt, r.UpdatedAt)).ToList();
        }
    }
}
