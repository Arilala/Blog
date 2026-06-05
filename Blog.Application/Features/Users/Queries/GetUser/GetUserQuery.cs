using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Users.Queries.GetUser
{
    public record GetUserQuery(int Id) : IQuery<GetUserQueryDto?>;

}
