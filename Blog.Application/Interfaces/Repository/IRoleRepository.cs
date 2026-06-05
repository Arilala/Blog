using Blog.Domain.Entity;

namespace Blog.Application.Interfaces.Repository
{
    public interface IRoleRepository : IRepository<RoleEntity>
    {
        Task<RoleEntity?> GetRoleByNameAsync(string roleName, CancellationToken ct = default);
        Task<bool> ExistsByNameAsync(string roleName, CancellationToken ct = default);
    }
}
