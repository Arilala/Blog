using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Features.Users.Queriers.GetAllUsers
{
    public record GetAllUsersQueryDto(int Id, string Username, string Email, DateTime CreatedAt);
}
