use master
GO

Drop database if exists TEST_2_1_2023
Create database TEST_2_1_2023
GO

use TEST_2_1_2023
GO

Drop table if exists Student
Create table Student(
	Id int primary key identity,
	[Name] nvarchar(max),
	Gender bit
)
GO

Insert into Student([Name],Gender)
Values (N'Phạm Phúc Lợi',0)
GO 2