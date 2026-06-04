IF NOT EXISTS (SELECT *
               FROM   sys.tables
               WHERE  name = 'Users'
                      AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        CREATE TABLE dbo.Users (
            Id           INT           IDENTITY (1, 1) NOT NULL,
            Username     VARCHAR (255) NOT NULL,
            Email        VARCHAR (255) NOT NULL,
            PasswordHash VARCHAR (255) NOT NULL,
            CreatedAt    DATETIME2     DEFAULT GETDATE() NOT NULL,
            UpdatedAt    DATETIME2     NULL,
            CONSTRAINT PK_Users PRIMARY KEY (Id),
            CONSTRAINT UQ_Users_Username UNIQUE (Username),
            CONSTRAINT UQ_Users_Email UNIQUE (Email)
        );
    END