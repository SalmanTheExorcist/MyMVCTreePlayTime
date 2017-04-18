CREATE TABLE [dbo].[LevelMains] (
    [LevelMainID]               INT            IDENTITY (1, 1) NOT NULL,
    [Title]                     NVARCHAR (MAX) NULL,
    [MyLevelsHolderMugID]       INT            NOT NULL,
    [SubLevelOne_SubLevelOneID] INT            NULL,
    CONSTRAINT [PK_dbo.LevelMains] PRIMARY KEY CLUSTERED ([LevelMainID] ASC),
    CONSTRAINT [FK_dbo.LevelMains_dbo.MyLevelsHolderMugs_MyLevelsHolderMugID] FOREIGN KEY ([MyLevelsHolderMugID]) REFERENCES [dbo].[MyLevelsHolderMugs] ([MyLevelsHolderMugID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.LevelMains_dbo.SubLevelOnes_SubLevelOne_SubLevelOneID] FOREIGN KEY ([SubLevelOne_SubLevelOneID]) REFERENCES [dbo].[SubLevelOnes] ([SubLevelOneID])
);


GO
CREATE NONCLUSTERED INDEX [IX_MyLevelsHolderMugID]
    ON [dbo].[LevelMains]([MyLevelsHolderMugID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SubLevelOne_SubLevelOneID]
    ON [dbo].[LevelMains]([SubLevelOne_SubLevelOneID] ASC);

