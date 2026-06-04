namespace Blog.Domain.Entity
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
