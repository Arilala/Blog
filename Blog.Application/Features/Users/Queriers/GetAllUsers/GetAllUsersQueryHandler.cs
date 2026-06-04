using Blog.Application.Interfaces.Repository;
using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Users.Queriers.GetAllUsers
{
    internal sealed class GetAllUsersQueryHandler(IUserRepository userRepository)
        : IQueryHandler<GetAllUsersQuery, List<GetAllUsersQueryDto>>
    {
        public async Task<List<GetAllUsersQueryDto>> HandleAsync(
            GetAllUsersQuery message,
            CancellationToken cancellationToken = default
        )
        {
            var reutls = await userRepository.GetAllAsync(cancellationToken);

            return reutls
                .Select(x => new GetAllUsersQueryDto(x.Id, x.Username, x.Email, x.CreatedAt))
                .ToList();
        }
    }
}
