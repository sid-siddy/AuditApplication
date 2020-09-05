IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200817104606_myfirstmigration')
BEGIN
    CREATE TABLE [Auditors] (
        [Id] int NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [Password] nvarchar(100) NOT NULL,
        [City] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Auditors] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200817104606_myfirstmigration')
BEGIN
    CREATE TABLE [AuditRequest] (
        [RequestId] int NOT NULL IDENTITY,
        [AuditorFK] int NULL,
        [ClientId] int NOT NULL,
        [AuditorComments] nvarchar(max) NULL,
        [ClientResponse] nvarchar(max) NULL,
        CONSTRAINT [PK_AuditRequest] PRIMARY KEY ([RequestId]),
        CONSTRAINT [FK_AuditRequest_Auditors_AuditorFK] FOREIGN KEY ([AuditorFK]) REFERENCES [Auditors] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200817104606_myfirstmigration')
BEGIN
    CREATE TABLE [Portfolio] (
        [AuditId] int NOT NULL,
        [PortfolioName] nvarchar(50) NOT NULL,
        [ClientId] int NOT NULL,
        [ClientName] nvarchar(max) NULL,
        [AuditorFK] int NOT NULL,
        CONSTRAINT [PK_Portfolio] PRIMARY KEY ([AuditId]),
        CONSTRAINT [FK_Portfolio_Auditors_AuditorFK] FOREIGN KEY ([AuditorFK]) REFERENCES [Auditors] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200817104606_myfirstmigration')
BEGIN
    CREATE INDEX [IX_AuditRequest_AuditorFK] ON [AuditRequest] ([AuditorFK]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200817104606_myfirstmigration')
BEGIN
    CREATE INDEX [IX_Portfolio_AuditorFK] ON [Portfolio] ([AuditorFK]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200817104606_myfirstmigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200817104606_myfirstmigration', N'3.1.6');
END;

GO

