namespace Blog.Application.Features.Roles.Queries.GetRole
{
    public record GetRoleQueryDto(
        int Id,
        string? Description,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
