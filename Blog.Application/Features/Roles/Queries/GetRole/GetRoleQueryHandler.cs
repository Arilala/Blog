using Blog.Application.Interfaces.Repository;
using Blog.Domain.Entity;
using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Roles.Queries.GetRole
{
    internal sealed class GetRoleQueryHandler(IRoleRepository roleRepository)
        : IQueryHandler<GetRoleQuery, GetRoleQueryDto?>
    {
        public async Task<GetRoleQueryDto?> HandleAsync(
            GetRoleQuery message,
            CancellationToken cancellationToken = default
        )
        {
            RoleEntity? roleEntity = await roleRepository.GetByIdAsync(message.Id);
            if (roleEntity == null)
            {
                return null;
            }
            return new GetRoleQueryDto(
                roleEntity.Id,
                roleEntity.Description,
                roleEntity.CreatedAt,
                roleEntity.UpdatedAt
            );
        }
    }
}
