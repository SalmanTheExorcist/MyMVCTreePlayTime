CREATE TABLE [dbo].[SubLevelFours] (
    [SubLevelFourID]              INT            IDENTITY (1, 1) NOT NULL,
    [Title]                       NVARCHAR (MAX) NULL,
    [SubLevelThreeID]             INT            NOT NULL,
    [MyLevelsHolderMugID]         INT            NOT NULL,
    [SubLevelFive_SubLevelFiveID] INT            NULL,
    CONSTRAINT [PK_dbo.SubLevelFours] PRIMARY KEY CLUSTERED ([SubLevelFourID] ASC),
    CONSTRAINT [FK_dbo.SubLevelFours_dbo.SubLevelFives_SubLevelFive_SubLevelFiveID] FOREIGN KEY ([SubLevelFive_SubLevelFiveID]) REFERENCES [dbo].[SubLevelFives] ([SubLevelFiveID])
);


GO
CREATE NONCLUSTERED INDEX [IX_SubLevelFive_SubLevelFiveID]
    ON [dbo].[SubLevelFours]([SubLevelFive_SubLevelFiveID] ASC);

