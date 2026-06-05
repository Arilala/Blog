using FluentValidation;

namespace Blog.Application.Features.Roles.Commands.CreateRole
{
    internal class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is mandatory")
                .NotNull().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters")
                .Matches(@"^[a-zA-Z]+$").WithMessage("'{PropertyName}' can only contain alphabetical characters (a-z, A-Z).");


            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters");
        }
    }
}
