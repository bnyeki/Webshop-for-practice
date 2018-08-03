CREATE TABLE [dbo].[Connect] (
    [UserId]   NVARCHAR (128) NOT NULL,
    [AvatarId] INT            NOT NULL,
    CONSTRAINT [PK_Connect_1] PRIMARY KEY CLUSTERED ([UserId] ASC, [AvatarId] ASC),
    CONSTRAINT [FK_Connect_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Connect_Avatar] FOREIGN KEY ([AvatarId]) REFERENCES [dbo].[Avatar] ([Id])
);

