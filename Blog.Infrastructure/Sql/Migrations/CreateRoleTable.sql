IF NOT EXISTS (SELECT *
               FROM   sys.tables
               WHERE  name = 'Roles'
                      AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        CREATE TABLE dbo.Roles (
            Id          INT            IDENTITY (1, 1) NOT NULL,
            Name        VARCHAR (50)   NOT NULL UNIQUE,
            Description NVARCHAR (200) NULL,
            CreatedAt   DATETIME2      DEFAULT GETDATE() NOT NULL,
            UpdatedAt   DATETIME2      NULL,
            CONSTRAINT PK_Roles PRIMARY KEY (Id),
            CONSTRAINT UQ_Roles_Name UNIQUE (Name),
            CONSTRAINT CHK_Roles_Name CHECK (Name NOT LIKE '%[^a-zA-Z]%')
        );
    END