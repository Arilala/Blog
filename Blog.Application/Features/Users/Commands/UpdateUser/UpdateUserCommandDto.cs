namespace Blog.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommandDto(int Id, string Username, string Email, DateTime CreatedAt);

}
