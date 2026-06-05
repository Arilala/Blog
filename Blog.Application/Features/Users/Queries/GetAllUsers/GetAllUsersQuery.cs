using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IQuery<List<GetAllUsersQueryDto>>;

}
