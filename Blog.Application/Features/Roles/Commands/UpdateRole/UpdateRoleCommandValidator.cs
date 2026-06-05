using FluentValidation;

namespace Blog.Application.Features.Roles.Commands.UpdateRole
{
    internal class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is mandatory")
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than 0");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is mandatory")
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not exceed 50 characters")
                .Matches(@"^[a-zA-Z]+$")
                .WithMessage(
                    "'{PropertyName}' can only contain alphabetical characters (a-z, A-Z)."
                );

            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed 200 characters");
        }
    }
}
