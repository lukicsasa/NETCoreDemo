CREATE TABLE [dbo].[Exam]
(
	[UserId] BIGINT NOT NULL,
	[SubjectId] BIGINT NOT NULL, 
	[Date] DATETIME NOT NULL,
    [Grade] INT NOT NULL CHECK (Grade >= 5 AND Grade <= 10), 
    CONSTRAINT [PK_Exam] PRIMARY KEY ([UserId], [SubjectId]), 
    CONSTRAINT [FK_Exam_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Exam_Subject] FOREIGN KEY ([SubjectId]) REFERENCES [Subject]([Id])
)
