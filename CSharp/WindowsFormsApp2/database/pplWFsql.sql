use master
Go

Drop database if exists PPL_WF
Create database PPL_WF
GO

use PPL_WF
Go

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
Values (N'Phạm',N'C',1,'12/01/2003')
Go

Create proc GetAllStudents
As
Begin
	Select * from Student
End
Go

Create proc UpdateStudent
@fname nvarchar(50),
@lname nvarchar(50),
@gender bit,
@dob date, 
@id int
As
Begin 
	Update Student
	Set FirstName = @fname, LastName = @lname, Gender = @gender, DoB = @dob
	Where Id = @id
End
Go