CREATE TABLE [dbo].[Subject]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Name] NVARCHAR(250) NOT NULL, 
    [Archived] BIT NOT NULL DEFAULT 0, 
    [CreatedBy] BIGINT NOT NULL, 
    CONSTRAINT [FK_Subject_User] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([Id])

)
