using FluentValidation;
using LiteBus.Commands.Abstractions;

namespace Blog.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is mandatory")
                .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("{PropertyName} is mandatory")
               .NotNull().WithMessage("{PropertyName} is required")
               .EmailAddress().WithMessage("{PropertyName} not valid Email")
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 255 caracters");


            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("{PropertyName} is mandatory")
                .NotNull().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 255 caracters");


           
        }
    }
}
