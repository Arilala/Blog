using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(int Id) : ICommand<bool>;
}
