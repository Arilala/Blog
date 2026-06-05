SELECT CAST (CASE WHEN EXISTS (SELECT 1
                               FROM   Roles
                               WHERE  Name = @Name) THEN 1 ELSE 0 END AS BIT);