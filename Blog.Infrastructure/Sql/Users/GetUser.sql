SELECT Id,
       Username,
       Email,
       CreatedAt
FROM   Users
WHERE  Id = @Id;