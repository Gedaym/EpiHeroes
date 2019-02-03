CREATE TABLE [dbo].[Hero]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Name] VARCHAR(50) NOT NULL, 
    [Sexe] VARCHAR(50) NOT NULL CHECK ([Sexe] IN ('Woman', 'Man', 'Other')), 
    [ComicId] INT NOT NULL, 
    CONSTRAINT [FK_Hero_Comic] FOREIGN KEY (ComicId) REFERENCES [Comic]([Id]) ON DELETE CASCADE
)
