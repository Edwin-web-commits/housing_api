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

