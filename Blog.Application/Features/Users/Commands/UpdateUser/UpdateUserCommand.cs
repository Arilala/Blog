using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(int Id, string Username, string Email, string PasswordHash) : ICommand<bool>;
}
