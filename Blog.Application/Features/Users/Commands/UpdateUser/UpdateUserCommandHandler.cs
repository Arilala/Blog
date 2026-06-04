using Blog.Application.Exceptions;
using Blog.Application.Features.Users.Commands.CreateUser;
using Blog.Application.Interfaces.Repository;
using Blog.Application.Interfaces.SqlFactory;
using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Users.Commands.UpdateUser
{
    internal sealed class UpdateUserCommandHandler(IUserRepository userRepository) : ICommandHandler<UpdateUserCommand, bool>

    {
        public async Task<bool> HandleAsync(UpdateUserCommand command, CancellationToken cancellationToken = default)
        {
            var validationResult = new UpdateUserCommandValidator().Validate(command);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid user data provided.",validationResult);
            }

            var userUpdate = await userRepository.GetByIdAsync(command.Id, cancellationToken);
            if (userUpdate == null)
            {
                throw new BadRequestException($"User with ID {command.Id} not found.");
            }
            var userRecord = await userRepository.ExistsByNameOrEmailAsync(command.Username, command.Email, cancellationToken);
            if (userRecord)
            {
                throw new BadRequestException("A user with the same email or username already exists.");
            }
            userUpdate.Username = command.Username;
            userUpdate.Email = command.Email;
            userUpdate.UpdatedAt = DateTime.UtcNow;
            return await userRepository.UpdateAsync(userUpdate, cancellationToken);
        }
    }
}
