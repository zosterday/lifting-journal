IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231210231103_InitialCreate'
)
BEGIN
    CREATE TABLE [Lift] (
        [Id] int NOT NULL IDENTITY,
        [ClientId] nvarchar(max) NOT NULL,
        [DateLifted] datetime2 NOT NULL,
        [LiftType] int NOT NULL,
        [Weight] int NOT NULL,
        [Sets] int NOT NULL,
        [Reps] int NOT NULL,
        CONSTRAINT [PK_Lift] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231210231103_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231210231103_InitialCreate', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231220091143_Updated_Lift_Model'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231220091143_Updated_Lift_Model', N'8.0.0');
END;
GO

COMMIT;
GO

