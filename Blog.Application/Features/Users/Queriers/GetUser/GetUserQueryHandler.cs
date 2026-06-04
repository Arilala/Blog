using Blog.Application.Interfaces.Repository;
using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Users.Queriers.GetUser
{
    internal sealed class GetUserQueryHandler(IUserRepository userRepository)
        : IQueryHandler<GetUserQuery, GetUserQueryDto?>
    {
        public async Task<GetUserQueryDto?> HandleAsync(
            GetUserQuery request,
            CancellationToken cancellationToken = default
        )
        {
            var userEntity = await userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (userEntity == null)
            {
                return null;
            }
            return new GetUserQueryDto(
                userEntity.Id,
                userEntity.Username,
                userEntity.Email,
                userEntity.CreatedAt
            );
        }
    }
}
