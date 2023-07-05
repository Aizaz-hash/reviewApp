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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE TABLE [characters] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [DOB] datetime2 NOT NULL,
        CONSTRAINT [PK_characters] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE TABLE [countries] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_countries] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE TABLE [reviewers] (
        [Id] int NOT NULL IDENTITY,
        [firstName] nvarchar(max) NOT NULL,
        [lastName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_reviewers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE TABLE [characterCategories] (
        [CharacterId] int NOT NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_characterCategories] PRIMARY KEY ([CharacterId], [CategoryId]),
        CONSTRAINT [FK_characterCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_characterCategories_characters_CharacterId] FOREIGN KEY ([CharacterId]) REFERENCES [characters] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE TABLE [owners] (
        [Id] int NOT NULL IDENTITY,
        [firstName] nvarchar(max) NOT NULL,
        [lastName] nvarchar(max) NOT NULL,
        [Gym] nvarchar(max) NOT NULL,
        [countryId] int NOT NULL,
        CONSTRAINT [PK_owners] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_owners_countries_countryId] FOREIGN KEY ([countryId]) REFERENCES [countries] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE TABLE [reviews] (
        [Id] int NOT NULL IDENTITY,
        [rating] int NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [text] nvarchar(max) NOT NULL,
        [reviewerId] int NOT NULL,
        [characterId] int NOT NULL,
        CONSTRAINT [PK_reviews] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_reviews_characters_characterId] FOREIGN KEY ([characterId]) REFERENCES [characters] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_reviews_reviewers_reviewerId] FOREIGN KEY ([reviewerId]) REFERENCES [reviewers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE TABLE [characterOwners] (
        [CharacterId] int NOT NULL,
        [OwnerId] int NOT NULL,
        CONSTRAINT [PK_characterOwners] PRIMARY KEY ([CharacterId], [OwnerId]),
        CONSTRAINT [FK_characterOwners_characters_CharacterId] FOREIGN KEY ([CharacterId]) REFERENCES [characters] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_characterOwners_owners_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [owners] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE INDEX [IX_characterCategories_CategoryId] ON [characterCategories] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE INDEX [IX_characterOwners_OwnerId] ON [characterOwners] ([OwnerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE INDEX [IX_owners_countryId] ON [owners] ([countryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE INDEX [IX_reviews_characterId] ON [reviews] ([characterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    CREATE INDEX [IX_reviews_reviewerId] ON [reviews] ([reviewerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623204703_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230623204703_init', N'7.0.8');
END;
GO

COMMIT;
GO

