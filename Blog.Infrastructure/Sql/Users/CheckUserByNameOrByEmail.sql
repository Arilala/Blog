SELECT CAST (CASE WHEN EXISTS (SELECT 1
                               FROM   Users
                               WHERE  Email = @Email
                                      OR Username = @Username) THEN 1 ELSE 0 END AS BIT);