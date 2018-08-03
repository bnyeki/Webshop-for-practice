CREATE TABLE [dbo].[Product] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (50) NOT NULL,
    [Price]          INT          NOT NULL,
    [ProductImageId] INT          NOT NULL,
    [AvatarCastId]   INT          NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_ProductImage] FOREIGN KEY ([ProductImageId]) REFERENCES [dbo].[ProductImage] ([Id])
);

