USE [SSDBtest]; -- 切换到数据库
USE [master]; -- 切换到数据库

CREATE DATABASE [StudySystemDB];

DROP DATABASE [StudySystemDB];

-- 如果Student表存在就删除它，否则就啥也不做
DROP DATABASE IF EXISTS [StudySystemDB]

alter database [SSDBtest]
set single_user with rollback immediate --将数据库回滚到原始配置状态

-- 将数据库备份到
BACKUP DATABASE [SSDBtest] TO DISK = 'E:\echo\zero\adn\adnWork\StudySystem\staticpage\wwwroot\test\sql\SSDBtest.bak' 
-- 根据备份恢复数据库
RESTORE DATABASE [SSDBtest] FROM DISK = 'E:\echo\zero\adn\adnWork\StudySystem\staticpage\wwwroot\test\sql\SSDBtest.bak' 


--create database test001;
--go
--use test001;

--create table teacher
--(
--	id int 
--);

--use master;
--drop database test001;

create table student 
(
	id int
);

alter table student add score decimal(3,1);
alter table student drop column score;
alter table student alter column score float not null;

drop table Teacher;

--

insert [Table] (Id,[name],age) values (3,N'zhuliang2',33);

INSERT [Table]([Name], Age) VALUES(2,N'陈元',23);

USE TEST001;
ALTER TABLE student 
--ADD [name] NVARCHAR NULL;
--ALTER COLUMN [name] NVARCHAR(4000);
--ALTER COLUMN score float null;
ALTER COLUMN id int  null;

INSERT student ([name],score) VALUES (N'ZL',56.7)

SELECT * FROM student;

SELECT score FROM student;

BEGIN TRANSACTION
--UPDATE student SET score = 30;
--DELETE student;
TRUNCATE TABLE Student;

ROLLBACK;

SELECT 1
--WHERE 3 < 2
WHERE EXISTS (
	SELECT * FROM [Table]
	WHERE ID = 2

	--SELECT * FROM [Table]
	--WHERE ID = 5
)

SELECT * FROM [Table]
WHERE isfemale IS NULL

-------------------------------

CREATE TABLE [Student] 
(
	Id INT NULL,
	[Name] NVARCHAR(20) NULL,
	Enroll DATE NULL,
	Age INT NULL
);

CREATE TABLE [Teacher] 
(
	Id INT NULL,
	[Name] NVARCHAR(20) NULL,
	Age INT NULL,
	Gengder BIT NULL
);

SELECT * FROM Student;

SELECT * FROM Teacher;

ALTER TABLE Student 
--ADD InviteBy INT;
--ADD TeacherId INT;
--DROP COLUMN InviteBy;
--DROP CONSTRAINT FK_Student_Teacher_Id;

--ADD CONSTRAINT FK_Student_InviteBy_Student_Id 
--FOREIGN KEY (InviteBy) 
--REFERENCES Student (Id);

ADD CONSTRAINT FK_Student_TeacherId_Teacher_Id 
FOREIGN KEY (TeacherId) 
REFERENCES Teacher (Id);


ALTER TABLE Student 
--ALTER COLUMN Id INT NOT NULL;
ADD CONSTRAINT PK_Student_Id 
PRIMARY KEY (Id);

ALTER TABLE Teacher 
ADD CONSTRAINT UQ_Teacher_Id 
UNIQUE (Id);

CREATE TABLE [Major] 
(
	Id INT NOT NULL CONSTRAINT PK_Major_Id PRIMARY KEY,
	[Name] NVARCHAR(20) NULL,
	TaughtBy INT CONSTRAINT FK_Major_TaughtBy_Teacher_Id FOREIGN KEY REFERENCES Teacher (Id)
);

SELECT * FROM Major;

SELECT * FROM Student;

SELECT * FROM Teacher;

SELECT * 
FROM Student s JOIN Teacher t 
ON s.TeacherId = t.Id;

SELECT 
s.Id AS StudentId,
s.[Name] AS StudentName,
s.TeacherId AS TeacherBy,
t.Id AS TeacherId,
t.[Name] AS TeacherName 
FROM Student s JOIN Teacher t 
ON s.TeacherId = t.Id;

SELECT * 
FROM Student s LEFT JOIN Teacher t 
ON s.TeacherId = t.Id;

SELECT * 
FROM Student s FULL JOIN Teacher t 
ON s.TeacherId = t.Id;

SELECT * 
FROM Student s CROSS JOIN Teacher t;


SELECT * 
FROM Student s JOIN Teacher t 
ON s.TeacherId = t.Id;

SELECT * FROM Student;

SELECT * FROM Teacher;

BEGIN TRAN
DELETE s 
FROM Student s JOIN Teacher t ON s.TeacherId = t.Id 
WHERE t.[Name] = N'李老师';

ROLLBACK;

BEGIN TRAN
UPDATE s SET [Name] = N'赵六'  
FROM Student s JOIN Teacher t ON s.TeacherId = t.Id 
WHERE t.[Name] = N'李老师';

ROLLBACK;


SELECT 
s.Id AS StudentId,
s.[Name] AS StudentName,
s.InviteBy,
i.Id,
i.[Name] 
FROM Student s LEFT JOIN Student i 
ON s.InviteBy = i.Id;

SELECT 
s.Id,
s.[Name],
i.Id,
i.[Name]
FROM Student s JOIN Student i 
ON s.[Name] = i.[Name]
WHERE s.Id > i.Id;

SELECT * FROM Student;

BEGIN TRAN 
DELETE s 
FROM Student s JOIN Student i 
ON s.[Name] = i.[Name]
WHERE s.Id > i.Id;

ROLLBACK;


SELECT * 
FROM Major m JOIN Student s 
ON m.TaughtBy = s.Id;



SELECT * FROM Student;

SELECT * FROM Teacher;

ALTER TABLE Student 
--NOCHECK CONSTRAINT ALL;

CHECK CONSTRAINT ALL;

ALTER TABLE Major
--NOCHECK CONSTRAINT ALL;

CHECK CONSTRAINT ALL;


BEGIN TRAN
delete teacher where id = 2;
UPDATE Teacher SET Id = 5 WHERE Id = 2;

ROLLBACK;


SELECT * FROM Major;

SELECT * FROM Student;

SELECT * FROM Teacher;

ALTER TABLE Major 
--DROP CONSTRAINT FK_Major_TaughtBy_Teacher_Id;
ADD CONSTRAINT FK_Major_TaughtBy_Teacher_Id 
FOREIGN KEY (TaughtBy) 
REFERENCES Teacher (Id)
--ON DELETE CASCADE
ON DELETE SET NULL
--ON UPDATE SET NULL
ON UPDATE CASCADE

ALTER TABLE Student 
--DROP CONSTRAINT FK_Student_TeacherId_Teacher_Id;
ADD CONSTRAINT FK_Student_TeacherId_Teacher_Id 
FOREIGN KEY (TeacherId) 
REFERENCES Teacher (Id)
ON DELETE CASCADE
--ON DELETE SET NULL
ON UPDATE SET NULL
--ON UPDATE CASCADE



CREATE TABLE [xue] 
(
	Id INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(20) NULL,
	Age INT NULL
);

CREATE TABLE [shi] 
(
	Id INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(20) NULL
);

CREATE TABLE [xue2shi] 
(
	id INT NOT NULL,
	[xid] INT NULL,
	[sid] INT NULL
);

--DROP TABLE xue2shi;

SELECT * FROM xue;

SELECT * FROM shi;

SELECT * FROM xue2shi;

SELECT 
x.Id,
x.[Name],
t.xid,
t.[sid],
s.Id,
s.[Name] 
FROM xue x 
FULL JOIN xue2shi t ON x.Id = t.xid 
FULL JOIN shi s ON t.[sid] = s.Id

------------------------------

SELECT * FROM Major
SELECT * FROM shi
SELECT * FROM student
SELECT * FROM [Table]
SELECT * FROM Teacher
SELECT * FROM xue
SELECT * FROM xue2shi

-----------------------------------------------

IF EXISTS(SELECT NULL) PRINT 'YES' ELSE PRINT 'NO'
IF NOT EXISTS(SELECT NULL) PRINT 'Yes' ELSE PRINT 'NO'
IF 4 IN (1,2,3,NULL) PRINT 'YES' ELSE PRINT 'NO'
IF 4 NOT IN(1,2,NULL) PRINT 'YES' ELSE PRINT 'NO'


-------------------------------

SELECT * FROM student

ALTER TABLE Student 
ADD Score INT NULL

SELECT 
ROW_NUMBER() OVER (
	PARTITION BY Age 
	ORDER BY Score
) AS RID,
Id,
[Name],
Age,
Score
FROM Student

SELECT 
ROW_NUMBER() OVER (
	PARTITION BY Age 
	ORDER BY Score
) AS RID,
Id,
[Name],
Age,
MAX(Score) OVER (
	PARTITION BY Age 
	--ORDER BY Score
) AS MAS,
Score,
MAX(Score) OVER (
	PARTITION BY Age 
	--ORDER BY Score
) - Score AS CHA
FROM Student

-----------------------------

SELECT 
Id,
[Name],
Age,
Score,
CASE  
	WHEN Score >= 90 THEN N'优秀'
	WHEN Score >= 80 THEN N'良好'
	WHEN Score >= 70 THEN N'一般'
	WHEN Score >= 60 THEN N'及格'
	ELSE N'不及格'
END AS Grade
FROM Student

SELECT * FROM student

ALTER TABLE Student 
ADD Grade NVARCHAR(10) NULL

UPDATE Student SET Grade = 
CASE  
	WHEN Score >= 90 THEN N'优秀'
	WHEN Score >= 80 THEN N'良好'
	WHEN Score >= 70 THEN N'一般'
	WHEN Score >= 60 THEN N'及格'
	ELSE N'不及格'
END

SELECT * FROM [Table]

SELECT 
[name],
isfemale,
CASE isfemale
	WHEN 1 THEN N'男'
	WHEN 0 THEN N'女'
	ELSE N'未知'
END AS BIE
FROM [Table]

CREATE TABLE StudentScore (
	Id INT NOT NULL,
	Sname NVARCHAR(10) NOT NULL,
	Major NVARCHAR(10) NOT NULL,
	Score INT NULL
)

SELECT * FROM StudentScore

SELECT 
--Id,
Sname,
--Major,
--Score,
MAX(CASE Major
	WHEN 'C#' THEN Score ELSE -1
END) AS C#,
MAX(CASE Major
	WHEN 'JAVA' THEN Score ELSE -1
END) AS JAVA,
MAX(CASE Major
	WHEN 'JS' THEN Score ELSE -1
END) AS JS,
MAX(CASE Major
	WHEN 'SQL' THEN Score ELSE -1
END) AS SQL
FROM StudentScore
GROUP BY Sname


------------------------------------------------------
--数据库：14 - 并发冲突和锁

DBCC USEROPTIONS


-------------------------------------------------------

GO
CREATE FUNCTION tt (@num INT)
RETURNS TABLE
RETURN SELECT TOP (@num) * FROM Problem
GO

SELECT * FROM tt(10)

GO 
CREATE FUNCTION ct (@id INT, @na NVARCHAR(20))
RETURNS @t TABLE (Id INT, Na VARCHAR(20))
AS
BEGIN
	INSERT @t VALUES (@id, @na)
	RETURN
END
GO

SELECT * FROM ct(2,N'zs')
