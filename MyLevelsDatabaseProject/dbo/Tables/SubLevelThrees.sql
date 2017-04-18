CREATE TABLE [dbo].[SubLevelThrees] (
    [SubLevelThreeID]             INT            IDENTITY (1, 1) NOT NULL,
    [Title]                       NVARCHAR (MAX) NULL,
    [SubLevelTwoID]               INT            NOT NULL,
    [MyLevelsHolderMugID]         INT            NOT NULL,
    [SubLevelFour_SubLevelFourID] INT            NULL,
    CONSTRAINT [PK_dbo.SubLevelThrees] PRIMARY KEY CLUSTERED ([SubLevelThreeID] ASC),
    CONSTRAINT [FK_dbo.SubLevelThrees_dbo.SubLevelFours_SubLevelFour_SubLevelFourID] FOREIGN KEY ([SubLevelFour_SubLevelFourID]) REFERENCES [dbo].[SubLevelFours] ([SubLevelFourID])
);


GO
CREATE NONCLUSTERED INDEX [IX_SubLevelFour_SubLevelFourID]
    ON [dbo].[SubLevelThrees]([SubLevelFour_SubLevelFourID] ASC);

