
CREATE DATABASE TaskSQL;

BACKUP DATABASE TaskSQL TO DISK = 'E:\echo\zero\adn\adnWork\StudySystem\staticpage\wwwroot\test\sql\TaskSQL.bak';

DROP DATABASE TaskSQL;

RESTORE DATABASE TaskSQL FROM DISK = 'E:\echo\zero\adn\adnWork\StudySystem\staticpage\wwwroot\test\sql\TaskSQL.bak';

USE TaskSQL;

CREATE TABLE [User] 
(
	ID INT NOT NULL,
	UserName NVARCHAR(20) NOT NULL,
	[Password] NVARCHAR(20) NOT NULL,
	Describe NVARCHAR(40) NULL
);

CREATE TABLE Keyword 
(
	[Name] NVARCHAR(10) NOT NULL,
	Used INT NULL
);

ALTER TABLE [User] 
--ADD InvitedBy INT NULL;
--ALTER COLUMN InvitedBy NVARCHAR(20);
--DROP COLUMN InvitedBy;
ALTER COLUMN [Password] NVARCHAR(20) NULL;

CREATE TABLE Problem 
(
	Id INT NOT NULL,
	Title NVARCHAR(20) NOT NULL,
	NeedRemoteHelp BIT NULL,
	Reward INT NULL,
	PublishDateTime DATETIME NOT NULL
);

SELECT * FROM [User];

INSERT [User] (ID,UserName,[Password]) VALUES (1,'17bang','1234');

INSERT [User] (ID,UserName,[Password]) VALUES (2,'Admin',NULL);

INSERT [User] (ID,UserName,[Password]) VALUES (3,'Admin-1','');

INSERT [User] (ID,UserName,[Password]) VALUES (4,'SuperAdmin','123456');

BEGIN TRANSACTION
UPDATE [User] SET Password = 0;

ROLLBACK;

BEGIN TRANSACTION
--DELETE [User];
TRUNCATE TABLE [User];

ROLLBACK;


SELECT * FROM Keyword;

BEGIN TRAN
DROP TABLE Keyword;

ROLLBACK;

SELECT * FROM [User] WHERE [Password] IS NULL OR [Password] = '';

BEGIN TRAN
DELETE [User] WHERE UserName LIKE '%Admin%' OR UserName LIKE '%17bang%';

ROLLBACK;

SELECT * FROM Problem;

INSERT Problem (Id,Title,NeedRemoteHelp,Reward,PublishDateTime) VALUES (1,N'如何搭建运行环境',1,10,'2019-9-10 09:10:20');
INSERT Problem (Id,Title,NeedRemoteHelp,Reward,PublishDateTime) VALUES (2,N'如何更改VS界面主题',0,22,'2019-9-11 10:10:20');
INSERT Problem (Id,Title,NeedRemoteHelp,Reward,PublishDateTime) VALUES (3,N'如何更改VS编辑区字体',0,20,'2019-10-11 10:10:20');
INSERT Problem (Id,Title,NeedRemoteHelp,Reward,PublishDateTime) VALUES (4,N'如何调试程序',1,25,'2019-11-11 11:10:20');

BEGIN TRAN 
UPDATE Problem SET Title = N'【推荐】' + Title WHERE Reward > 10;

ROLLBACK;
COMMIT;

BEGIN TRAN 
UPDATE Problem SET Title = N'【加急】' + Title WHERE Reward > 20 AND PublishDateTime > '2019-10-10 00:00:00';

ROLLBACK;
COMMIT;

BEGIN TRAN 
DELETE Problem WHERE Title LIKE N'【%】%';

ROLLBACK;

INSERT Problem (Id,Title,NeedRemoteHelp,Reward,PublishDateTime) VALUES (5,N'【如何创建数据库',1,30,'2019-12-11 11:10:20');
INSERT Problem (Id,Title,NeedRemoteHelp,Reward,PublishDateTime) VALUES (6,N'如何创建数据库100%',1,35,'2019-12-12 11:10:20');
INSERT Problem (Id,Title,NeedRemoteHelp,Reward,PublishDateTime) VALUES (7,N'如何创建表100%',1,45,'2019-12-13 11:10:20');
INSERT Problem (Id,Title,NeedRemoteHelp,Reward,PublishDateTime) VALUES (8,N'如何创建表',1,45,'2019-12-13 11:10:20');

SELECT * FROM Problem WHERE Id >= 5 AND Title NOT LIKE N'%数据库%' AND Title LIKE '%#%%' ESCAPE '#';

SELECT * FROM Keyword;

INSERT Keyword ([Name],Used) VALUES (N'数据库',5);
INSERT Keyword ([Name],Used) VALUES (N'关系型',10);
INSERT Keyword ([Name],Used) VALUES (N'主键',15);
INSERT Keyword ([Name],Used) VALUES (N'外键',20);
INSERT Keyword ([Name],Used) VALUES (N'非空',0);
INSERT Keyword ([Name],Used) VALUES (N'约束',-1);
INSERT Keyword ([Name],Used) VALUES (N'唯一',NULL);
INSERT Keyword ([Name],Used) VALUES (N'编程',105);

SELECT [Name] FROM Keyword WHERE Used > 10 AND Used < 50;

BEGIN TRAN 
--UPDATE Keyword SET Used = 1 WHERE Used <= 0 OR Used IS NULL OR Used > 100;
DELETE Keyword WHERE Used % 2 != 0;

ROLLBACK;

SELECT 1 WHERE NULL % 2 != 0;


SELECT * FROM [User];

BEGIN TRAN 
ALTER TABLE [User] 
DROP COLUMN ID;

ROLLBACK;

--不能这么写
--ALTER TABLE [User] 
--ADD ID INT CONSTRAINT PK_User_ID PRIMARY KEY;

ALTER TABLE [User] 
--ADD CONSTRAINT PK_User_ID PRIMARY KEY (ID);
ADD CONSTRAINT UQ_User_UserName UNIQUE (UserName);
--DROP CONSTRAINT UQ_User_UserName;

SELECT * FROM Problem;

ALTER TABLE Problem 
--ALTER COLUMN NeedRemoteHelp BIT NOT NULL;
ALTER COLUMN NeedRemoteHelp BIT NULL;

ALTER TABLE Problem 
ADD CONSTRAINT CK_Problem_Reward CHECK (Reward >= 10);

SELECT * FROM Keyword;

ALTER TABLE Keyword 
--ADD Id INT IDENTITY (10,5);
--ADD Id INT IDENTITY (10,5) NOT NULL;--加不加NOT NULL都一样

ADD CONSTRAINT PK_Keyword_Id PRIMARY KEY (Id);
--DROP CONSTRAINT PK_Keyword_Id;
--DROP COLUMN Id;

INSERT Keyword ([Name],Used) VALUES (N'自增2',30)

SELECT * FROM [User];

ALTER TABLE [User] 
--ALTER COLUMN ID INT NOT NULL;
--ALTER COLUMN ID VARCHAR(50) NOT NULL;--不加NOT NULL，将修改为NULL。
--DROP CONSTRAINT PK_User_ID;
ADD CONSTRAINT PK_User_ID PRIMARY KEY (ID);

INSERT [User] (ID,UserName,[Password],Describe) VALUES (NEWID(),'ZHULIANG22','35456',NULL);

SELECT * FROM Problem;

ALTER TABLE Problem 
--DROP COLUMN Id;
ADD ID INT IDENTITY;