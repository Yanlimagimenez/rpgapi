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

CREATE TABLE [Armas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Armas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] nvarchar(max) NULL,
    [Longitude] nvarchar(max) NULL,
    [DataAcesso] datetime2 NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Personagens] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [PontosVida] int NOT NULL,
    [Forca] int NOT NULL,
    [Defesa] int NOT NULL,
    [Inteligencia] int NOT NULL,
    [Classe] int NOT NULL,
    [FotoPersonagem] varbinary(max) NULL,
    [usuarioId] int NULL,
    CONSTRAINT [PK_Personagens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Personagens_Usuarios_usuarioId] FOREIGN KEY ([usuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'FotoPersonagem', N'Inteligencia', N'Nome', N'PontosVida', N'usuarioId') AND [object_id] = OBJECT_ID(N'[Personagens]'))
    SET IDENTITY_INSERT [Personagens] ON;
INSERT INTO [Personagens] ([Id], [Classe], [Defesa], [Forca], [FotoPersonagem], [Inteligencia], [Nome], [PontosVida], [usuarioId])
VALUES (1, 1, 23, 17, NULL, 33, N'Frodo', 100, NULL),
(2, 1, 25, 15, NULL, 30, N'Sam', 100, NULL),
(3, 3, 21, 18, NULL, 35, N'Galadriel', 100, NULL),
(4, 2, 18, 18, NULL, 37, N'Gandalf', 100, NULL),
(5, 1, 17, 20, NULL, 31, N'Hobbit', 100, NULL),
(6, 3, 13, 21, NULL, 34, N'Celeborn', 100, NULL),
(7, 2, 11, 25, NULL, 35, N'Radagast', 100, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'FotoPersonagem', N'Inteligencia', N'Nome', N'PontosVida', N'usuarioId') AND [object_id] = OBJECT_ID(N'[Personagens]'))
    SET IDENTITY_INSERT [Personagens] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Username') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [DataAcesso], [Foto], [Latitude], [Longitude], [PasswordHash], [PasswordSalt], [Username])
VALUES (1, NULL, NULL, NULL, NULL, 0xB58997F14F3DF61F70B42371EE5F58266A7461F6AE016CEB4E4D68D126C0862A638B3B62CB5079FFE266BF60803783B4E7EA1E43D97A13B3DF1836A5FDBF9175, 0x3B6319F448A7A949A078C06275EF862E3C310386F3193967469B41766CD20FB1C9ABC27A12F3B091863787A817B6AD6016582680C47572239DD7C97C21072E592FD91655622A6AAD2A4E9C211B4E9627877CA3669A402FA7ABA50DD0A543CBF1DEB271B519F8E208DB735AFC2D84DF0B804A81091D11363A6820A0623A3CB189, N'UsuarioAdmin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Username') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

CREATE INDEX [IX_Personagens_usuarioId] ON [Personagens] ([usuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220408003313_MigracaoUsuario', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Armas] ADD [PersonagemId] int NOT NULL DEFAULT 0;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] ON;
INSERT INTO [Armas] ([Id], [Dano], [Nome], [PersonagemId])
VALUES (1, 35, N'Arco e Flecha', 1),
(2, 33, N'Espada', 2),
(3, 31, N'Machado', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] OFF;
GO

UPDATE [Usuarios] SET [PasswordHash] = 0xE7EAC5565EC85E0B31B639028302ED6A4DD087F8A5541CD4EFB7046B834CD70C88437719867E82560126286A3C81CECBFF6E3101D48D2DDAD7C36CF0D899EE46, [PasswordSalt] = 0x37C8E089A091DFF0549BC5C31BF360BBA41E5C6CAA67423D580BCB67FC273A76453229C258F26BA0E394725F599E146A23477BBC4F33DC2B231C461A0C17E227FBF449B0885840C0463E4B71C02AF0BCB445C86D344AF5282B702A6642AF8E8A31D0522CB0CBF7BC81EE24F6E84FDCEB52A54FDDA1E83FC170D8732155B181AA
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Armas_PersonagemId] ON [Armas] ([PersonagemId]);
GO

ALTER TABLE [Armas] ADD CONSTRAINT [FK_Armas_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220408011521_MigracaoUmParaUm', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Habilidades] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Habilidades] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PersonagemHabilidades] (
    [PersonagemId] int NOT NULL,
    [HabilidadeId] int NOT NULL,
    CONSTRAINT [PK_PersonagemHabilidades] PRIMARY KEY ([PersonagemId], [HabilidadeId]),
    CONSTRAINT [FK_PersonagemHabilidades_Habilidades_HabilidadeId] FOREIGN KEY ([HabilidadeId]) REFERENCES [Habilidades] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonagemHabilidades_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] ON;
INSERT INTO [Habilidades] ([Id], [Dano], [Nome])
VALUES (1, 39, N'Adormecer'),
(2, 41, N'Congelar'),
(3, 37, N'Hipnotizar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] OFF;
GO

UPDATE [Usuarios] SET [PasswordHash] = 0xC5BD2D5A81138B96D1A67CC033E9E82F63B1FF75844B172476B649869B73FD21838D996DD7DCBCAF2A183DE456C9FC62C7FADB3914E697CC6C25B1E7AF0CC8E4, [PasswordSalt] = 0x5D8DDDD02EE1C8D8E3D22921BE3913716510FD1AB5873A0657C0D2BEA4383019E2049F52B5733290CB09F5807D952184E2467E7E8BBAF177937DEDE5242ABBEFD8A460B2A6E44BD148329018A8D33F872DC1D1D454B938DABA1BF02FE674B420242435545FC3346433E3A03243CA91F23F29CC4C3896504DA273AFFC2CD70A73
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] ON;
INSERT INTO [PersonagemHabilidades] ([HabilidadeId], [PersonagemId])
VALUES (1, 1),
(1, 5),
(2, 1),
(2, 2),
(2, 3),
(2, 6),
(3, 3),
(3, 4),
(3, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] OFF;
GO

CREATE INDEX [IX_PersonagemHabilidades_HabilidadeId] ON [PersonagemHabilidades] ([HabilidadeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220408013647_MigracaoMuitosParaMuitos', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Personagens] DROP CONSTRAINT [FK_Personagens_Usuarios_usuarioId];
GO

DROP INDEX [IX_Armas_PersonagemId] ON [Armas];
GO

EXEC sp_rename N'[Personagens].[usuarioId]', N'UsuarioId', N'COLUMN';
GO

EXEC sp_rename N'[Personagens].[IX_Personagens_usuarioId]', N'IX_Personagens_UsuarioId', N'INDEX';
GO

ALTER TABLE [Personagens] ADD [Derrotas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Disputa] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Vitorias] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Disputas] (
    [Id] int NOT NULL IDENTITY,
    [DataDisputa] datetime2 NULL,
    [AtacanteId] int NOT NULL,
    [OponenteId] int NOT NULL,
    [Narracao] nvarchar(max) NULL,
    CONSTRAINT [PK_Disputas] PRIMARY KEY ([Id])
);
GO

UPDATE [Personagens] SET [Nome] = N'yan'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Nome] = N'dainel'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Nome] = N'hiague'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Nome] = N'brune'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Nome] = N'aalaina'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Nome] = N'coiah'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Nome] = N'ga'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [PasswordHash] = 0x4630A8A647FC8263732CB2EFE10FCD6EBF62CD4E518FA280B21C23210C526B8DAC33D55DEB7909F6B356782AB6E560AFD8EAE969D10EDD6B6E089A1B76BFB6B8, [PasswordSalt] = 0x0E003B840135191583E192EB78747B2848C37AC430BF12184A5ECF147BE1CD81E92A8EC107B546568B1C743FD53EE3060E291714781EABB6BB6519E1EE8BB5B78B261FFC4F3EDDC79A67FA04C2479E71EC2B9382814009C1D8A2A93A7CC6815A4900F5A169E6F90A001677139D11FDC946C343B5D0C80A656815A2B7C163B4B5
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

CREATE UNIQUE INDEX [IX_Armas_PersonagemId] ON [Armas] ([PersonagemId]);
GO

ALTER TABLE [Personagens] ADD CONSTRAINT [FK_Personagens_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220519202847_MigracaoDisputas', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usuarios] SET [PasswordHash] = 0x1CD7D73D7F67CEC5C08C6BC1DA183D033B075CED8DF1ABAB93BE314ADDF2CACB566B8DEEB355003C11E2BCDFE287E7096D1D32D97C024962B87402F4EF3B9D93, [PasswordSalt] = 0x05DC375831F5A2E5A40295C307E491B631663DFFC3DBBF7E5F92BB9C4D3B5CB6A6188B425D2494C54EA22CF185785123A6FFA9DC81C5DC4A545BD3C2C338A1436BFC2FB216B4A4BBB7D15B0DA836721F9E883EC1149B28B0BD99656175B4D047CE01D5237D06B02232B3DB3616FB719030FE1F4EA04ACCAAEE068AACC82F6502
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220519211609_scriptFinal', N'5.0.15');
GO

COMMIT;
GO

