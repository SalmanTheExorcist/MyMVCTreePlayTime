CREATE TABLE [dbo].[SubLevelTwoes] (
    [SubLevelTwoID]                 INT            IDENTITY (1, 1) NOT NULL,
    [Title]                         NVARCHAR (MAX) NULL,
    [SubLevelOneID]                 INT            NOT NULL,
    [MyLevelsHolderMugID]           INT            NOT NULL,
    [SubLevelThree_SubLevelThreeID] INT            NULL,
    CONSTRAINT [PK_dbo.SubLevelTwoes] PRIMARY KEY CLUSTERED ([SubLevelTwoID] ASC),
    CONSTRAINT [FK_dbo.SubLevelTwoes_dbo.SubLevelThrees_SubLevelThree_SubLevelThreeID] FOREIGN KEY ([SubLevelThree_SubLevelThreeID]) REFERENCES [dbo].[SubLevelThrees] ([SubLevelThreeID])
);


GO
CREATE NONCLUSTERED INDEX [IX_SubLevelThree_SubLevelThreeID]
    ON [dbo].[SubLevelTwoes]([SubLevelThree_SubLevelThreeID] ASC);

