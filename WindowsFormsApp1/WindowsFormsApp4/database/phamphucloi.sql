USE MASTER 
GO

DROP DATABASE IF EXISTS PHAMPHUCLOI
CREATE DATABASE PHAMPHUCLOI
GO

USE PHAMPHUCLOI
GO

DROP TABLE IF EXISTS tblStudent
CREATE TABLE tblStudent(
	stuId int primary key identity,
	stuPass nvarchar(200),
	stuName varchar(50),
	stuPhone varchar(50),
	stuEmail varchar(50),
	deptId int
)
GO

DROP TABLE IF EXISTS tblSubject
CREATE TABLE tblSubject(
	deptId int primary key identity,
	deptName nvarchar(50),
	deptCredits int
)
GO

DROP TABLE IF EXISTS tblExam
CREATE TABLE tblExam(
	examId int primary key identity,
	examName varchar(50),
	examMark varchar(50),
	examDate varchar(50),
	stuId int,
	couId int,
)
GO

DROP TABLE IF EXISTS tblCourse
CREATE TABLE tblCourse(
	couId int primary key identity,
	couName varchar(50),
	couSemester int
)
GO


ALTER TABLE tblStudent
ADD CONSTRAINT FK_tblStudent_tblSubject
FOREIGN KEY (deptId)
REFERENCES tblSubject(deptId)
GO

ALTER TABLE tblExam
ADD CONSTRAINT FK_tblExam_tblStudent
FOREIGN KEY (stuId)
REFERENCES tblStudent(stuId)
GO

ALTER TABLE tblExam
ADD CONSTRAINT FK_tblExam_tblCourse
FOREIGN KEY (couId)
REFERENCES tblCourse(couId)
GO

DROP PROC IF EXISTS SelectAllSubject
GO

CREATE PROC SelectAllSubject
AS
BEGIN
	select * from tblSubject
END
GO

--insert Subject.
DROP PROC IF EXISTS InsertSubject
GO

CREATE PROC InsertSubject
@name varchar(50), @credit int
AS
BEGIN
	Insert into tblSubject(deptName, deptCredits)
	Values(@name, @credit)
END
GO