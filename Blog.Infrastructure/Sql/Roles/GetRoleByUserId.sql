SELECT Id,
       Name,
       Description,
       Roles.CreatedAt,
       Roles.UpdatedAt
FROM   Roles
       INNER JOIN
       UserRoles
       ON UserRoles.RoleId = Roles.Id
WHERE  UserRoles.UserId = @UserId;