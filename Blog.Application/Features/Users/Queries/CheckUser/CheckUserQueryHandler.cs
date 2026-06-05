using Blog.Application.Interfaces.Repository;
using Blog.Application.Interfaces.Security;
using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Users.Queries.CheckUser
{
    internal sealed class CheckUserQueryHandler(
        IUserRepository userRepository,
        IPasswordService passwordService
    ) : IQueryHandler<CheckUserQuery, CheckUserQueryDto?>
    {
        public async Task<CheckUserQueryDto?> HandleAsync(
            CheckUserQuery message,
            CancellationToken cancellationToken = default
        )
        {
            var userEnity = await userRepository.GetUserByNameAsync(
                message.Username,
                cancellationToken
            );
            if (userEnity == null)
            {
                return null;
            }
            bool checkPassword = passwordService.VerifyPassword(
                message.Password,
                userEnity.PasswordHash
            );
            if (!checkPassword)
            {
                return null;
            }
            return new CheckUserQueryDto(
                userEnity.Id,
                userEnity.Username,
                userEnity.Email,
                userEnity.CreatedAt
            );
        }
    }
}
