INSERT  INTO Users (Username, Email, PasswordHash)
VALUES            (@Username, @Email, @PasswordHash);

SELECT CAST (SCOPE_IDENTITY() AS INT);