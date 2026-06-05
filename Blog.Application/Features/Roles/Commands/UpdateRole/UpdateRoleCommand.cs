using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Roles.Commands.UpdateRole
{
    public record UpdateRoleCommand(int Id, string Name, string? Description = null)
        : ICommand<bool>;
}
