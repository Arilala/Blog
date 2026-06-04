namespace Blog.Domain.Entity
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}