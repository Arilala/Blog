UPDATE Users
SET    Username = @Username,
       Email    = @Email,
       UpdatedAt   = @UpdatedAt
WHERE  Id = @Id;