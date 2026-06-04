IF NOT EXISTS (SELECT *
               FROM   sys.tables
               WHERE  name = '_Version'
                      AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        CREATE TABLE dbo._Version (
            Version INT NOT NULL
        );
    END