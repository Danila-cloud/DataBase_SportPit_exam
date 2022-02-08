CREATE TABLE [dbo].[Contracts] (
    [Id]           UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Order Number] INT              NOT NULL,
    [Products]     NVARCHAR (50)    NOT NULL,
    [Number]       INT              DEFAULT ((1)) NOT NULL,
    [Price]        INT              DEFAULT ((0)) NULL,
    [Sum]          INT              DEFAULT ((0)) NULL,
    [Date]         DATE             DEFAULT (sysdatetime()) NOT NULL
);

