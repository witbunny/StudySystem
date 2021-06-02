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

	SELECT * FROM [Table]
	WHERE ID = 5
)

SELECT * FROM [Table]
WHERE isfemale IS NULL