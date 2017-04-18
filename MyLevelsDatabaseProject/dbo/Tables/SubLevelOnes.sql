CREATE TABLE [dbo].[SubLevelOnes] (
    [SubLevelOneID]             INT            IDENTITY (1, 1) NOT NULL,
    [Title]                     NVARCHAR (MAX) NULL,
    [LevelMainID]               INT            NOT NULL,
    [MyLevelsHolderMugID]       INT            NOT NULL,
    [SubLevelTwo_SubLevelTwoID] INT            NULL,
    CONSTRAINT [PK_dbo.SubLevelOnes] PRIMARY KEY CLUSTERED ([SubLevelOneID] ASC),
    CONSTRAINT [FK_dbo.SubLevelOnes_dbo.SubLevelTwoes_SubLevelTwo_SubLevelTwoID] FOREIGN KEY ([SubLevelTwo_SubLevelTwoID]) REFERENCES [dbo].[SubLevelTwoes] ([SubLevelTwoID])
);


GO
CREATE NONCLUSTERED INDEX [IX_SubLevelTwo_SubLevelTwoID]
    ON [dbo].[SubLevelOnes]([SubLevelTwo_SubLevelTwoID] ASC);

