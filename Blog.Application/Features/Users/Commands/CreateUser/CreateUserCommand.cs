

using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand(string Username, string Email, string Password) : ICommand<int>;
}
