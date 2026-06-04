namespace Blog.Application.Features.Users.Queriers.GetUser
{
    public record GetUserQueryDto(int Id, string Username, string Email, DateTime CreatedAt);

}
