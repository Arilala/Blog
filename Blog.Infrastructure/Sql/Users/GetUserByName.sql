SELECT Id,
       Username,
       Email,
       PasswordHash,
       CreatedAt
FROM   Users
WHERE  Username = @Username;