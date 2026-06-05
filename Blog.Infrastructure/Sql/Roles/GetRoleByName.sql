SELECT Id,
       Name,
       Description,
       CreatedAt,
       UpdatedAt
FROM   dbo.Roles
WHERE  Name = @Name;