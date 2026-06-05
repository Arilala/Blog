using Blog.Application.Interfaces.Repository;
using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Roles.Queries.GetAllRole
{
    internal sealed class GetAllRoleQueryHandler(IRoleRepository roleRepository)
        : IQueryHandler<GetAllRoleQuery, List<GetAllRoleQueryDto>>
    {
        public async Task<List<GetAllRoleQueryDto>> HandleAsync(
            GetAllRoleQuery message,
            CancellationToken cancellationToken = default
        )
        {
            var reutls = await roleRepository.GetAllAsync(cancellationToken);
            return reutls
                .Select(x => new GetAllRoleQueryDto(
                    x.Id,
                    x.Name,
                    x.Description,
                    x.CreatedAt,
                    x.UpdatedAt
                ))
                .ToList();
        }
    }
}
