using Blog.Domain.Entity;

namespace Blog.Application.Interfaces.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity?> GetUserByEmailAsync(string email, CancellationToken ct = default);
        Task<bool> ExistsByNameOrEmailAsync(string name, string email, CancellationToken ct = default);
        Task<UserEntity?> GetUserByNameAsync(string name, CancellationToken ct = default);
        Task<bool> AddRoleToUserAsync(int userId, int roleId, CancellationToken ct = default);
    }
}
