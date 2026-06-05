UPDATE Roles
SET    Name        = @Name,
       Description = @Description,
       CreatedAt   = @CreatedAt,
       UpdatedAt   = @UpdatedAt
WHERE  Id = @Id;