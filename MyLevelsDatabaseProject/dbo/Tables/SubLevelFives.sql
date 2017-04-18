CREATE TABLE [dbo].[SubLevelFives] (
    [SubLevelFiveID]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]               NVARCHAR (MAX) NULL,
    [SubLevelFourID]      INT            NOT NULL,
    [MyLevelsHolderMugID] INT            NOT NULL,
    CONSTRAINT [PK_dbo.SubLevelFives] PRIMARY KEY CLUSTERED ([SubLevelFiveID] ASC)
);

