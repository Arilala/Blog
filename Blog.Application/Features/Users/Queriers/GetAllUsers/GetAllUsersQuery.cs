using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Users.Queriers.GetAllUsers
{
    public record GetAllUsersQuery : IQuery<List<GetAllUsersQueryDto>>;

}
