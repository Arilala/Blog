using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
