using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Roles.Commands.DeleteRole
{
    public record DeleteRoleCommand(int Id) : ICommand<bool>;
}
