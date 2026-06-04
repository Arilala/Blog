UPDATE Users
SET    Username = @Username,
       Email    = @Email
WHERE  Id = @Id;