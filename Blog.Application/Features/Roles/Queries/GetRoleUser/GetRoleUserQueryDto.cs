namespace Blog.Application.Features.Roles.Queries.GetRoleUser
{
    public record GetRoleUserQueryDto(
        int Id,
        string? Description,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
