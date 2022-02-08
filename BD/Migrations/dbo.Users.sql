CREATE TABLE [dbo].[Users] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [Name]               NVARCHAR (50)    NOT NULL,
    [Email]              NVARCHAR (50)    NOT NULL,
    [Phone]              NVARCHAR (50)    NULL,
    [Password]           NVARCHAR (50)    NOT NULL,
    [isPhoneVerificated] BIT              DEFAULT ((0)) NULL,
    [isEmailVerificated] BIT              DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

