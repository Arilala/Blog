using FluentValidation;

namespace Blog.Application.Features.Users.Commands.CreateUser
{
    internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is mandatory")
                .NotNull().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} not valid Email")
                .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 caracters");


            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("{PropertyName} is mandatory")
                .NotNull().WithMessage("{PropertyName} is required")
                .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 caracters");


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} is mandatory")
                .NotNull().WithMessage("{PropertyName} is required")
                .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 caracters")
                .MinimumLength(4).WithMessage("{PropertyName} Must be at least 4 characters");
        }
    }
}
