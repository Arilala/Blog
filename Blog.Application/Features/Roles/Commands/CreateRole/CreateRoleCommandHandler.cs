using Blog.Application.Exceptions;
using Blog.Application.Interfaces.Repository;
using Blog.Domain.Entity;
using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Roles.Commands.CreateRole
{
    internal sealed class CreateRoleCommandHandler(IRoleRepository roleRepository) : ICommandHandler<CreateRoleCommand, int>
    {
        public async Task<int> HandleAsync(CreateRoleCommand message, CancellationToken cancellationToken = default)
        {
           
            var validationResult = new CreateRoleCommandValidator().Validate(message);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid role data.", validationResult);
            }
            var existingRole =await roleRepository.ExistsByNameAsync(message.Name, cancellationToken);
            if (existingRole)
            {
                throw new BadRequestException("Role already exists.");
            }
            // create role
            var role = new RoleEntity
            {
                Name = message.Name,
                Description = message.Description
            };
            return await roleRepository.AddAsync(role, cancellationToken);
          
        }
    }

}


