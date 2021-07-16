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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE TABLE [Cities] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Country] nvarchar(max) NOT NULL,
        [LastUpdatedOn] datetime2 NOT NULL,
        [LastUpdatedBy] int NOT NULL,
        CONSTRAINT [PK_Cities] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[Cities]'))
        SET IDENTITY_INSERT [Cities] ON;
    EXEC(N'INSERT INTO [Cities] ([Id], [Country], [LastUpdatedBy], [LastUpdatedOn], [Name])
    VALUES (1, N''South Africa'', 1, ''2021-03-04T22:41:29.4646872+03:00'', N''Johannesburg'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[Cities]'))
        SET IDENTITY_INSERT [Cities] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[Cities]'))
        SET IDENTITY_INSERT [Cities] ON;
    EXEC(N'INSERT INTO [Cities] ([Id], [Country], [LastUpdatedBy], [LastUpdatedOn], [Name])
    VALUES (2, N''South Africa'', 2, ''2021-03-04T22:41:29.4943690+03:00'', N''Cape Town'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[Cities]'))
        SET IDENTITY_INSERT [Cities] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[Cities]'))
        SET IDENTITY_INSERT [Cities] ON;
    EXEC(N'INSERT INTO [Cities] ([Id], [Country], [LastUpdatedBy], [LastUpdatedOn], [Name])
    VALUES (3, N''South Africa'', 3, ''2021-03-04T22:41:29.4943728+03:00'', N''Nelspruit'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[Cities]'))
        SET IDENTITY_INSERT [Cities] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210304194131_AddedCitiesAndIdentity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210304194131_AddedCitiesAndIdentity', N'5.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210309185259_AddedProperty')
BEGIN
    CREATE TABLE [Properties] (
        [Id] int NOT NULL IDENTITY,
        [SellRent] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [PType] nvarchar(max) NULL,
        [BHK] int NOT NULL,
        [FType] nvarchar(max) NULL,
        [Price] float NOT NULL,
        [BuiltArea] int NOT NULL,
        [CarpetArea] int NOT NULL,
        [Image] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [CityId] int NOT NULL,
        [Description] nvarchar(max) NULL,
        [FloorNo] int NOT NULL,
        [TotalFloor] int NOT NULL,
        [AOP] int NOT NULL,
        [Bathrooms] int NOT NULL,
        [MainEntrance] nvarchar(max) NULL,
        [Gated] int NOT NULL,
        [Security] int NOT NULL,
        [Maintanance] int NOT NULL,
        [Possesion] nvarchar(max) NULL,
        [PostedOn] datetime2 NOT NULL,
        CONSTRAINT [PK_Properties] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Properties_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210309185259_AddedProperty')
BEGIN
    EXEC(N'UPDATE [Cities] SET [LastUpdatedOn] = ''2021-03-09T21:52:58.3908492+03:00''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210309185259_AddedProperty')
BEGIN
    EXEC(N'UPDATE [Cities] SET [LastUpdatedOn] = ''2021-03-09T21:52:58.3939743+03:00''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210309185259_AddedProperty')
BEGIN
    EXEC(N'UPDATE [Cities] SET [LastUpdatedOn] = ''2021-03-09T21:52:58.3939784+03:00''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210309185259_AddedProperty')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AOP', N'Address', N'BHK', N'Bathrooms', N'BuiltArea', N'CarpetArea', N'CityId', N'Description', N'FType', N'FloorNo', N'Gated', N'Image', N'MainEntrance', N'Maintanance', N'Name', N'PType', N'Possesion', N'PostedOn', N'Price', N'Security', N'SellRent', N'TotalFloor') AND [object_id] = OBJECT_ID(N'[Properties]'))
        SET IDENTITY_INSERT [Properties] ON;
    EXEC(N'INSERT INTO [Properties] ([Id], [AOP], [Address], [BHK], [Bathrooms], [BuiltArea], [CarpetArea], [CityId], [Description], [FType], [FloorNo], [Gated], [Image], [MainEntrance], [Maintanance], [Name], [PType], [Possesion], [PostedOn], [Price], [Security], [SellRent], [TotalFloor])
    VALUES (1, 10, N''1 Street'', 1, 2, 1200, 900, 1, N''2 BHK, 2 Bathroom, 1 Car Parking'', N''Fully'', 3, 1, N'''', N''East'', 300, N''White House'', N''Duplex'', N''Ready to move'', ''2021-03-09T21:52:58.3988158+03:00'', 5000.0E0, 4, 1, 8)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AOP', N'Address', N'BHK', N'Bathrooms', N'BuiltArea', N'CarpetArea', N'CityId', N'Description', N'FType', N'FloorNo', N'Gated', N'Image', N'MainEntrance', N'Maintanance', N'Name', N'PType', N'Possesion', N'PostedOn', N'Price', N'Security', N'SellRent', N'TotalFloor') AND [object_id] = OBJECT_ID(N'[Properties]'))
        SET IDENTITY_INSERT [Properties] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210309185259_AddedProperty')
BEGIN
    CREATE INDEX [IX_Properties_CityId] ON [Properties] ([CityId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210309185259_AddedProperty')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210309185259_AddedProperty', N'5.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    EXEC(N'DELETE FROM [Cities]
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    EXEC(N'DELETE FROM [Cities]
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    EXEC(N'DELETE FROM [Properties]
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    EXEC(N'DELETE FROM [Cities]
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Properties]') AND [c].[name] = N'FType');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Properties] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Properties] DROP COLUMN [FType];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Properties]') AND [c].[name] = N'Image');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Properties] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Properties] DROP COLUMN [Image];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    EXEC sp_rename N'[Properties].[PostedOn]', N'LastUpdatedOn', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    EXEC sp_rename N'[Properties].[Possesion]', N'LastUpdatedBy', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    EXEC sp_rename N'[Properties].[PType]', N'Address2', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    EXEC sp_rename N'[Properties].[AOP]', N'PropertyTypeId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Properties]') AND [c].[name] = N'Gated');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Properties] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Properties] ALTER COLUMN [Gated] bit NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    ALTER TABLE [Properties] ADD [Age] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    ALTER TABLE [Properties] ADD [EstPossesionOn] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    ALTER TABLE [Properties] ADD [FurnishingTypeId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    ALTER TABLE [Properties] ADD [PostedBy] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    ALTER TABLE [Properties] ADD [ReadyToMove] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Cities]') AND [c].[name] = N'LastUpdatedBy');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Cities] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Cities] ALTER COLUMN [LastUpdatedBy] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    CREATE TABLE [FurnishingTypes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [LastUpdatedOn] datetime2 NOT NULL,
        [LastUpdatedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_FurnishingTypes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    CREATE TABLE [Photos] (
        [Id] nvarchar(450) NOT NULL,
        [ImageUrl] nvarchar(max) NULL,
        [IsPrimary] bit NOT NULL,
        [LastUpdatedOn] datetime2 NOT NULL,
        [LastUpdatedBy] nvarchar(max) NULL,
        [PropertyId] int NOT NULL,
        CONSTRAINT [PK_Photos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Photos_Properties_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Properties] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    CREATE TABLE [PropertyTypes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [LastUpdatedOn] datetime2 NOT NULL,
        [LastUpdatedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_PropertyTypes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    CREATE INDEX [IX_Properties_FurnishingTypeId] ON [Properties] ([FurnishingTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    CREATE INDEX [IX_Properties_PostedBy] ON [Properties] ([PostedBy]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    CREATE INDEX [IX_Properties_PropertyTypeId] ON [Properties] ([PropertyTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    CREATE INDEX [IX_Photos_PropertyId] ON [Photos] ([PropertyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    ALTER TABLE [Properties] ADD CONSTRAINT [FK_Properties_AspNetUsers_PostedBy] FOREIGN KEY ([PostedBy]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    ALTER TABLE [Properties] ADD CONSTRAINT [FK_Properties_FurnishingTypes_FurnishingTypeId] FOREIGN KEY ([FurnishingTypeId]) REFERENCES [FurnishingTypes] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    ALTER TABLE [Properties] ADD CONSTRAINT [FK_Properties_PropertyTypes_PropertyTypeId] FOREIGN KEY ([PropertyTypeId]) REFERENCES [PropertyTypes] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614150128_AddedNewEntities')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210614150128_AddedNewEntities', N'5.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614193121_SeedingData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[Cities]'))
        SET IDENTITY_INSERT [Cities] ON;
    EXEC(N'INSERT INTO [Cities] ([Id], [Country], [LastUpdatedBy], [LastUpdatedOn], [Name])
    VALUES (1, N''South Africa'', N''abcde'', ''2021-06-14T22:31:19.8872438+03:00'', N''Johannesburg''),
    (2, N''South Africa'', N''abcde'', ''2021-06-14T22:31:19.9212691+03:00'', N''Cape Town''),
    (3, N''South Africa'', N''abcde'', ''2021-06-14T22:31:19.9212722+03:00'', N''Nelspruit'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Country', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[Cities]'))
        SET IDENTITY_INSERT [Cities] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614193121_SeedingData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[FurnishingTypes]'))
        SET IDENTITY_INSERT [FurnishingTypes] ON;
    EXEC(N'INSERT INTO [FurnishingTypes] ([Id], [LastUpdatedBy], [LastUpdatedOn], [Name])
    VALUES (1, N''abcde'', ''2021-06-14T22:31:19.9242115+03:00'', N''Fully''),
    (2, N''abcde'', ''2021-06-14T22:31:19.9242855+03:00'', N''Semi''),
    (3, N''abcde'', ''2021-06-14T22:31:19.9242861+03:00'', N''Unfurnished'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[FurnishingTypes]'))
        SET IDENTITY_INSERT [FurnishingTypes] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614193121_SeedingData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[PropertyTypes]'))
        SET IDENTITY_INSERT [PropertyTypes] ON;
    EXEC(N'INSERT INTO [PropertyTypes] ([Id], [LastUpdatedBy], [LastUpdatedOn], [Name])
    VALUES (1, N''abcde'', ''2021-06-14T22:31:19.9239214+03:00'', N''Duplex''),
    (2, N''abcde'', ''2021-06-14T22:31:19.9240321+03:00'', N''House''),
    (3, N''abcde'', ''2021-06-14T22:31:19.9240334+03:00'', N''Apartment'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LastUpdatedBy', N'LastUpdatedOn', N'Name') AND [object_id] = OBJECT_ID(N'[PropertyTypes]'))
        SET IDENTITY_INSERT [PropertyTypes] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614193121_SeedingData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Address2', N'Age', N'BHK', N'Bathrooms', N'BuiltArea', N'CarpetArea', N'CityId', N'Description', N'EstPossesionOn', N'FloorNo', N'FurnishingTypeId', N'Gated', N'LastUpdatedBy', N'LastUpdatedOn', N'MainEntrance', N'Maintanance', N'Name', N'PostedBy', N'Price', N'PropertyTypeId', N'ReadyToMove', N'Security', N'SellRent', N'TotalFloor') AND [object_id] = OBJECT_ID(N'[Properties]'))
        SET IDENTITY_INSERT [Properties] ON;
    EXEC(N'INSERT INTO [Properties] ([Id], [Address], [Address2], [Age], [BHK], [Bathrooms], [BuiltArea], [CarpetArea], [CityId], [Description], [EstPossesionOn], [FloorNo], [FurnishingTypeId], [Gated], [LastUpdatedBy], [LastUpdatedOn], [MainEntrance], [Maintanance], [Name], [PostedBy], [Price], [PropertyTypeId], [ReadyToMove], [Security], [SellRent], [TotalFloor])
    VALUES (1, N''1 Street'', NULL, 2, 1, 2, 1200, 900, 1, N''2 BHK, 2 Bathroom, 1 Car Parking'', ''2021-06-14T22:31:19.9236200+03:00'', 3, 1, CAST(1 AS bit), N''abcde'', ''2021-06-14T22:31:19.9236648+03:00'', N''East'', 300, N''White House'', N''abcde'', 5000.0E0, 1, CAST(0 AS bit), 4, 1, 8)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Address2', N'Age', N'BHK', N'Bathrooms', N'BuiltArea', N'CarpetArea', N'CityId', N'Description', N'EstPossesionOn', N'FloorNo', N'FurnishingTypeId', N'Gated', N'LastUpdatedBy', N'LastUpdatedOn', N'MainEntrance', N'Maintanance', N'Name', N'PostedBy', N'Price', N'PropertyTypeId', N'ReadyToMove', N'Security', N'SellRent', N'TotalFloor') AND [object_id] = OBJECT_ID(N'[Properties]'))
        SET IDENTITY_INSERT [Properties] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614193121_SeedingData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Address2', N'Age', N'BHK', N'Bathrooms', N'BuiltArea', N'CarpetArea', N'CityId', N'Description', N'EstPossesionOn', N'FloorNo', N'FurnishingTypeId', N'Gated', N'LastUpdatedBy', N'LastUpdatedOn', N'MainEntrance', N'Maintanance', N'Name', N'PostedBy', N'Price', N'PropertyTypeId', N'ReadyToMove', N'Security', N'SellRent', N'TotalFloor') AND [object_id] = OBJECT_ID(N'[Properties]'))
        SET IDENTITY_INSERT [Properties] ON;
    EXEC(N'INSERT INTO [Properties] ([Id], [Address], [Address2], [Age], [BHK], [Bathrooms], [BuiltArea], [CarpetArea], [CityId], [Description], [EstPossesionOn], [FloorNo], [FurnishingTypeId], [Gated], [LastUpdatedBy], [LastUpdatedOn], [MainEntrance], [Maintanance], [Name], [PostedBy], [Price], [PropertyTypeId], [ReadyToMove], [Security], [SellRent], [TotalFloor])
    VALUES (2, N''1 Street'', NULL, 2, 1, 2, 1200, 900, 2, N''2 BHK, 2 Bathroom, 1 Car Parking'', ''2021-06-14T22:31:19.9237368+03:00'', 3, 2, CAST(1 AS bit), N''abcde'', ''2021-06-14T22:31:19.9237371+03:00'', N''East'', 300, N''Pandora'', N''abcde'', 5000.0E0, 2, CAST(0 AS bit), 4, 2, 8)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'Address2', N'Age', N'BHK', N'Bathrooms', N'BuiltArea', N'CarpetArea', N'CityId', N'Description', N'EstPossesionOn', N'FloorNo', N'FurnishingTypeId', N'Gated', N'LastUpdatedBy', N'LastUpdatedOn', N'MainEntrance', N'Maintanance', N'Name', N'PostedBy', N'Price', N'PropertyTypeId', N'ReadyToMove', N'Security', N'SellRent', N'TotalFloor') AND [object_id] = OBJECT_ID(N'[Properties]'))
        SET IDENTITY_INSERT [Properties] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210614193121_SeedingData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210614193121_SeedingData', N'5.0.3');
END;
GO

COMMIT;
GO

