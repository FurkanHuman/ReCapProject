CREATE TABLE [dbo].Car
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ModelYear] DATETIME NOT NULL, 
    [DailyPrice] MONEY NOT NULL, 
    [Description] NCHAR(10) NOT NULL
)
