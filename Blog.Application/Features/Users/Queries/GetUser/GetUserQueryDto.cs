namespace Blog.Application.Features.Users.Queries.GetUser
{
    public record GetUserQueryDto(int Id, string Username, string Email, DateTime CreatedAt);

}
