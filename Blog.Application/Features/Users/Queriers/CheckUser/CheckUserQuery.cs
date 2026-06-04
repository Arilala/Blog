using LiteBus.Queries.Abstractions;

namespace Blog.Application.Features.Users.Queriers.CheckUser
{
    public record CheckUserQuery(string Username, string Password) : IQuery<CheckUserQueryDto?>;
}
