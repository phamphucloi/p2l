use master
GO

Drop database if exists Pel
Create database Pel
GO

use Pel
GO

Drop table if exists Student
Create table Student(
	Id int primary key identity,
	[Name] nvarchar(max)
)
GO

Insert into Student([Name])
Values(N'Phạm Phúc Lợi 2')
GO