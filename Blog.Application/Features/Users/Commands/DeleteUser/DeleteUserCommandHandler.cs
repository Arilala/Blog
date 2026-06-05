using Blog.Application.Exceptions;
using Blog.Application.Interfaces.Repository;
using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Users.Commands.DeleteUser
{
    internal sealed class DeleteUserCommandHandler(IUserRepository userRepository)
        : ICommandHandler<DeleteUserCommand, bool>
    {
        public async Task<bool> HandleAsync(
            DeleteUserCommand command,
            CancellationToken cancellationToken = default
        )
        {
            var validationResult = new DeleteUserCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid user data.", validationResult);
            }


            var userExists = await userRepository.GetByIdAsync(command.Id, cancellationToken);
            if (userExists == null)
            {
                throw new NotFoundException(nameof(userExists), command.Id);
            }
            return await userRepository.DeleteAsync(command.Id, cancellationToken);
        }
    }
}
