CREATE TABLE [sHero].[Hero] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [DisplayName] NVARCHAR (MAX) NULL,
    [TypeId]      INT            NOT NULL,
    CONSTRAINT [PK_Hero] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Hero_HeroType_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [sHero].[HeroType] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Hero_TypeId]
    ON [sHero].[Hero]([TypeId] ASC);

