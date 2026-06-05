using FluentValidation;

namespace Blog.Application.Features.Roles.Commands.DeleteRole
{
    internal class DeleteRoleCommandValidator : FluentValidation.AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
