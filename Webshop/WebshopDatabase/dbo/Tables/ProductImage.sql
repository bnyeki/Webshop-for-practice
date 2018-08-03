CREATE TABLE [dbo].[ProductImage] (
    [Id]   INT             IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50)    NOT NULL,
    [Data] VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED ([Id] ASC)
);

