CREATE TABLE [dbo].[Products] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]        NVARCHAR (50)    NOT NULL,
	[CategoriesId]    UNIQUEIDENTIFIER  NOT NULL,
    [Price]       MONEY            DEFAULT ((0)) NULL,
    [Description] NVARCHAR (100)   NULL,
    [Quantity]    INT              DEFAULT ((0)) NOT NULL
);

