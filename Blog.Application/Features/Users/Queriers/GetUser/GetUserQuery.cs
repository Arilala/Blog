using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Users.Queriers.GetUser
{
    public record GetUserQuery(int Id) : IQuery<GetUserQueryDto?>;

}
