namespace Blog.Application.Features.Roles.Queries.GetAllRole
{
    public record GetAllRoleQueryDto(
        int Id,
        string Name,
        string? Description,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
