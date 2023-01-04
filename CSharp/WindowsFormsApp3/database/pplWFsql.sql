use master
Go

use PPL_WF2
Go

Drop database if exists PPL_WF2
Create database PPL_WF2
GO

Drop table if exists Student
GO

Create table Student(
	Id int primary key identity,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Gender bit,
	DoB date
)
GO

Insert into Student(FirstName,LastName,Gender,DoB) 
Values (N'Phạm',N'Lợi',1,'12/01/2003')
Go 5