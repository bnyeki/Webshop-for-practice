﻿CREATE TABLE [dbo].[AvatarImage] (
    [Id]   INT             IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50)    NOT NULL,
    [Data] VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_AvatarImage] PRIMARY KEY CLUSTERED ([Id] ASC)
);

