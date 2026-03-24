-- ============================================================
-- SQL Script: Create FollowMeFree Logging Table
-- Target: Microsoft SQL Server LocalDB
-- Run this script in SSMS against your FollowMeFree database
-- ============================================================

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Logs')
BEGIN
    CREATE TABLE [dbo].[Logs]
    (
        [Id]        INT             IDENTITY(1,1)   NOT NULL,
        [Timestamp] DATETIME2(7)                    NOT NULL,
        [LogLevel]  NVARCHAR(20)                    NOT NULL,
        [Source]    NVARCHAR(50)                     NOT NULL,
        [Category]  NVARCHAR(256)                   NOT NULL,
        [Message]   NVARCHAR(MAX)                   NOT NULL,
        [Exception] NVARCHAR(MAX)                   NULL,

        CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC)
    );

    -- Index for filtering by source (e.g. 'Service', 'API', etc.)
    CREATE NONCLUSTERED INDEX [IX_Logs_Source]
        ON [dbo].[Logs] ([Source]);

    -- Index for filtering/sorting by timestamp
    CREATE NONCLUSTERED INDEX [IX_Logs_Timestamp]
        ON [dbo].[Logs] ([Timestamp] DESC);

    -- Composite index for common query pattern: filter by source + time range
    CREATE NONCLUSTERED INDEX [IX_Logs_Source_Timestamp]
        ON [dbo].[Logs] ([Source], [Timestamp] DESC);

    PRINT 'Table [dbo].[Logs] created successfully.';
END
ELSE
BEGIN
    PRINT 'Table [dbo].[Logs] already exists. No changes made.';
END
GO
