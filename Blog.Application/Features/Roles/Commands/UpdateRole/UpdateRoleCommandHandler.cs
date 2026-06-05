using Blog.Application.Exceptions;
using Blog.Application.Interfaces.Repository;
using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Roles.Commands.UpdateRole
{
    internal sealed class UpdateRoleCommandHandler(IRoleRepository roleRepository)
        : ICommandHandler<UpdateRoleCommand, bool>
    {
        public async Task<bool> HandleAsync(
            UpdateRoleCommand message,
            CancellationToken cancellationToken = default
        )
        {
            //validator
            var validationResult = new UpdateRoleCommandValidator().Validate(message);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid role data", validationResult);
            }

            var role = await roleRepository.GetByIdAsync(message.Id, cancellationToken);

            if (role == null)
            {
                throw new NotFoundException(nameof(role), message.Id);
            }

            role.Name = message.Name;
            role.Description = message.Description;
            role.UpdatedAt = DateTime.UtcNow;

            return await roleRepository.UpdateAsync(role, cancellationToken);
        }
    }
}
