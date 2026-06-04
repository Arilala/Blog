SELECT Id,
       Username,
       Email,
       PasswordHash,
       CreatedAt
FROM   Users
WHERE  Email = @Email;