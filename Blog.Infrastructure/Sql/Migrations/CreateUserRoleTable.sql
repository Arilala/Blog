IF NOT EXISTS (SELECT *
               FROM   sys.tables
               WHERE  name = 'UserRoles'
                      AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        CREATE TABLE dbo.UserRoles (
            UserId    INT       NOT NULL,  
            RoleId    INT       NOT NULL,
            CreatedAt DATETIME2 DEFAULT GETDATE() NOT NULL,
            UpdatedAt DATETIME2 NULL,
            CONSTRAINT PK_UserRoles PRIMARY KEY (UserId, RoleId),
            CONSTRAINT FK_UserRoles_Users FOREIGN KEY (UserId) REFERENCES dbo.Users (Id),
            CONSTRAINT FK_UserRoles_Roles FOREIGN KEY (RoleId) REFERENCES dbo.Roles (Id)
        );
    END