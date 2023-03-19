CREATE DATABASE CGDatabase

GO
USE CGDatabase
GO

CREATE TABLE [User]
(
	[Id] INT PRIMARY KEY default NEWID(), 
    [UserName] NCHAR(50) NOT NULL, 
    [Email] NCHAR(50) NOT NULL, 
    [Password] NCHAR(20) NOT NULL,
	[Lecture] INT NOT NULL
)

GO
INSERT INTO [User] VALUES (NEWID(), 'admin', 'admin@admin.com', 'admin', 1)
INSERT INTO [User] VALUES (NEWID(), 'Betka Bozanova', 'betka@gmail.com', '1234', 7)
GO

SELECT * FROM [User]