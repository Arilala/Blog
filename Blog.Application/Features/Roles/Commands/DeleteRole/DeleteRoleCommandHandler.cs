using Blog.Application.Exceptions;
using Blog.Application.Interfaces.Repository;
using Blog.Domain.Entity;
using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Roles.Commands.DeleteRole
{
    internal sealed class DeleteRoleCommandHandler(IRoleRepository roleRepository) : ICommandHandler<DeleteRoleCommand, bool>
    {
        public async Task<bool> HandleAsync(DeleteRoleCommand message, CancellationToken cancellationToken = default)
        {
            var validationResult = new DeleteRoleCommandValidator().Validate(message);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid role ID", validationResult);
            }

            var role =await roleRepository.GetByIdAsync(message.Id, cancellationToken);

            if (role == null) { 
                throw new NotFoundException(nameof(role), message.Id);
            }
            
            return await roleRepository.DeleteAsync(role.Id, cancellationToken);
        }
    }
}
