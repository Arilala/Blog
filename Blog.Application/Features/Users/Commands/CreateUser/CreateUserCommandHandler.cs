using Blog.Application.Exceptions;
using Blog.Application.Interfaces.Repository;
using Blog.Application.Interfaces.Security;
using Blog.Domain.Entity;
using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Users.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler(
        IUserRepository userRepository,
        IPasswordService passwordService
    ) : ICommandHandler<CreateUserCommand, int>
    {
        public async Task<int> HandleAsync(
            CreateUserCommand command,
            CancellationToken cancellationToken = default
        )
        {
            var validationResult = new CreateUserCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid user data.", validationResult);
            }
                var userExists = await userRepository.ExistsByNameOrEmailAsync(
                command.Username,
                command.Email,
                cancellationToken
            );
            if (userExists)
            {
                throw new BadRequestException("A user with the same email or username already exists.");
            }
            UserEntity userEntity = new UserEntity
            {
                Username = command.Username,
                Email = command.Email,
                PasswordHash = passwordService.HashPassword(command.Password),
            };
            return await userRepository.AddAsync(userEntity, cancellationToken); 
        }
    }
}
