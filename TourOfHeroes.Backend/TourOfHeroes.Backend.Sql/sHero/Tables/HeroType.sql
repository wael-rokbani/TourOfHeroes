﻿CREATE TABLE [sHero].[HeroType] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_HeroType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

