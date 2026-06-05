using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Roles.Commands.CreateRole
{
    public record CreateRoleCommand(string Name, string? Description = null) : ICommand<int>;
}
