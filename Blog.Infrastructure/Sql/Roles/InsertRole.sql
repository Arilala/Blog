INSERT  INTO dbo.Roles (Name, Description)
VALUES                (@Name, @Description);

SELECT CAST (SCOPE_IDENTITY() AS INT);