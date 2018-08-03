CREATE TABLE [dbo].[Avatar] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [AvatarCastId] INT NOT NULL,
    [ProductId]    INT NOT NULL,
    [AvatarImaged] INT NOT NULL,
    CONSTRAINT [PK_Avatar] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Avatar_AvatarCast] FOREIGN KEY ([AvatarCastId]) REFERENCES [dbo].[AvatarCast] ([Id]),
    CONSTRAINT [FK_Avatar_AvatarImage] FOREIGN KEY ([AvatarImaged]) REFERENCES [dbo].[AvatarImage] ([Id]),
    CONSTRAINT [FK_Avatar_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

