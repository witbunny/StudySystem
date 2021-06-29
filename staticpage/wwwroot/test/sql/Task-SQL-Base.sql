
CREATE DATABASE TaskSQL;

BACKUP DATABASE TaskSQL TO DISK = 'E:\echo\zero\adn\adnWork\StudySystem\staticpage\wwwroot\test\sql\bak\TaskSQL.bak';

DROP DATABASE TaskSQL;

RESTORE DATABASE TaskSQL FROM DISK = 'E:\echo\zero\adn\adnWork\StudySystem\staticpage\wwwroot\test\sql\bak\TaskSQL.bak';

-----------------------

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

----------------------------

SELECT * FROM [Problem];

ALTER TABLE [Problem] 
ADD [Author] NVARCHAR(10);

UPDATE [Problem] SET [Author] = 'fei';

UPDATE [Problem] SET [Author] = 'bufei' WHERE ID = 4;

SELECT TOP 3 * FROM [Problem] WHERE [Author] = 'fei' ORDER BY [Reward] DESC;

SELECT [Author],[Reward],[Title] FROM [Problem] GROUP BY [Author],[Reward],[Title] ORDER BY [Author],[Reward] DESC;

SELECT * FROM [Problem];

SELECT [Author],COUNT([Reward]) AS [Count],SUM([Reward]) AS [Sum],AVG([Reward]) AS [Avg] FROM [Problem] GROUP BY [Author];

SELECT [Author],AVG([Reward]) AS [Avg] FROM [Problem] GROUP BY [Author] HAVING AVG([Reward]) < 10 ORDER BY AVG([Reward]);

SELECT [Author],[Reward] 
INTO [NewProblem] 
FROM [Problem];

SELECT * FROM [NewProblem];

INSERT [NewProblem] SELECT [Author],[Reward] FROM [Problem];

--------------------------------

CREATE TABLE [Message] 
(
	Id INT NOT NULL,
	FromUser NVARCHAR(20) NULL,
	ToUser NVARCHAR(20) NULL,
	UrgentLevel INT NULL,
	Kind NVARCHAR(10) NULL,
	HasRead BIT NULL,
	IsDelete BIT NULL,
	Content TEXT NOT NULL
);

ALTER TABLE [Message]
--ADD CONSTRAINT UQ_Message_Id UNIQUE (Id);
--DROP CONSTRAINT UQ_Message_Id;
ADD CONSTRAINT PK_Message_Id PRIMARY KEY (Id);
--ALTER COLUMN Content NVARCHAR(20) NOT NULL;
--ALTER COLUMN Content NTEXT NOT NULL;
--ALTER COLUMN Content NTEXT NULL;
--DROP CONSTRAINT PK_Message_Id;
--DROP COLUMN Id;
ADD ID INT IDENTITY;


-- [type]：1 聚集; >1 非聚集
SELECT [name], [type], is_unique, is_primary_key, is_unique_constraint 
FROM sys.indexes 
WHERE object_id = OBJECT_ID('Message');

CREATE UNIQUE INDEX IX_Message_Id ON [Message] (Id);

CREATE UNIQUE CLUSTERED INDEX IX_Message_FromUser_ToUser ON [Message] (FromUser,ToUser);

CREATE INDEX IX_Message_FromUser ON [Message] (FromUser);


DROP INDEX [Message].IX_Message_Id;

DROP INDEX [Message].IX_Message_FromUser_ToUser;

SELECT * FROM [Message]
WHERE FromUser = N'peideluo';
--WHERE Id = 2;

SELECT FromUser FROM [Message]
WHERE FromUser = N'peideluo';

INSERT [Message] 
SELECT FromUser,ToUser,UrgentLevel,Kind,HasRead,IsDelete,Content FROM [Message];

---------------------------------------
--多张表：外键 / Cascade / 三大范式 / ER模型

--1.

SELECT * FROM [User];
SELECT * FROM [Profile];

CREATE TABLE [Profile] 
(
	[ID] INT CONSTRAINT PK_Profile_ID PRIMARY KEY NOT NULL,
	[Portrait] NVARCHAR(200) NOT NULL,
	[Gender] BIT NOT NULL,
	[BirthYear] INT NOT NULL,
	[BirthMonth] TINYINT NOT NULL,
	[Constellation] TINYINT NOT NULL,
	[Keywords] NVARCHAR(200) NOT NULL,
	[Description] NVARCHAR(255) NULL
);

ALTER TABLE [User]
DROP COLUMN Describe;

DELETE [User];

INSERT [Profile] VALUES (1,'E:\echo\zero\adn\adnWork\StudySystem\staticpage\wwwroot\Images\1.jpg',1,1987,11,8,N'Windows 操作系统 VisualStudio 工具软件 C# 编程开发语言 ',N'喜欢钻研的技术宅');
INSERT [User] VALUES (1,'Scorpio','aa123456');

INSERT [Profile] VALUES (2,'E:\echo\zero\adn\adnWork\StudySystem\staticpage\wwwroot\Images\2.jpg',0,1987,10,7,N'Windows 操作系统 VisualStudio 工具软件 C# 编程开发语言 ',N'喜欢钻研的技术宅0');
INSERT [User] VALUES (2,'Libra','bb123456');

SELECT 
U.ID,
U.UserName,
F.BirthYear,
F.BirthMonth,
F.Constellation
FROM [User] U JOIN [Profile] F ON U.ID = F.ID
WHERE U.ID = 2;

ALTER TABLE [Profile] 
ADD CONSTRAINT FK_Profile_ID_User_ID 
FOREIGN KEY (ID) 
REFERENCES [User] (ID) 
ON DELETE CASCADE 
ON UPDATE CASCADE;

ALTER TABLE [User] 
--DROP CONSTRAINT PK_User_ID;
--ALTER COLUMN ID INT NOT NULL;
ADD CONSTRAINT PK_User_ID PRIMARY KEY (ID);

SELECT * FROM [User];
SELECT * FROM [Profile];

BEGIN TRAN
--DELETE [User] WHERE ID = 2;
UPDATE [User] SET ID = 3 WHERE ID =2;

ROLLBACK;

--2.

CREATE TABLE [Credit] 
(
	[Id] INT CONSTRAINT PK_Credit_ID PRIMARY KEY NOT NULL,
	[UserID] INT NOT NULL,
	[GetTime] DATETIME NOT NULL,
	[Category] TINYINT NOT NULL,
	[Reason] NVARCHAR(200) NULL,
	[Points] INT NOT NULL
);

--3.



ALTER TABLE Problem 
--DROP COLUMN ID,Author;
ADD Id INT  NULL,
Content NTEXT  NULL,
Keywords NVARCHAR(200)  NULL,
ToWhom INT NULL,
InReality BIT  NULL,
UserID INT  NULL;

SELECT * FROM [User];
SELECT * FROM Problem;

ALTER TABLE [Problem] 
ADD CONSTRAINT FK_Problem_UserID_User_ID 
FOREIGN KEY (UserID) 
REFERENCES [User] (ID) 
ON DELETE CASCADE 
ON UPDATE CASCADE;

BEGIN TRAN 
DELETE [User] WHERE ID = 2;

ROLLBACK;

--4.

SELECT * FROM Problem;
SELECT * FROM Keyword;
SELECT * FROM Problem2Keyword;

ALTER TABLE Keyword 
--DROP COLUMN Id;
--DROP CONSTRAINT PK_Keyword_Id;
ADD Id INT;

CREATE TABLE [Problem2Keyword] 
(
	[Id] INT NOT NULL,
	[PID] INT NULL,
	[KID] INT NULL
);

ALTER TABLE [Problem2Keyword] 
ADD CONSTRAINT FK_Problem2Keyword_PID_Problem_ID 
FOREIGN KEY (PID) 
REFERENCES Problem (ID) 
ON DELETE CASCADE 
ON UPDATE CASCADE;

ALTER TABLE Problem 
--ALTER COLUMN ID INT NOT NULL;
ADD CONSTRAINT PK_Problem_ID 
PRIMARY KEY (ID);

ALTER TABLE [Problem2Keyword] 
ADD CONSTRAINT FK_Problem2Keyword_KID_Keyword_ID 
FOREIGN KEY (KID) 
REFERENCES Keyword (ID) 
ON DELETE CASCADE 
ON UPDATE CASCADE;

ALTER TABLE Keyword
--ALTER COLUMN ID INT NOT NULL;
ADD CONSTRAINT PK_Keyword_ID 
PRIMARY KEY (ID);


SELECT * FROM Problem;
SELECT * FROM Keyword;
SELECT * FROM Problem2Keyword;

SELECT 
P.ID,
P.Title,
P.Keywords,
T.PID,
T.KID,
K.ID,
K.[Name]
FROM Problem P 
JOIN Problem2Keyword T ON P.ID = T.PID 
JOIN Keyword K ON T.KID = K.ID
WHERE P.ID = 1;

SELECT 
K.ID,
K.[Name],
T.KID,
T.PID,
P.ID,
P.Title,
P.Keywords
FROM Problem P 
JOIN Problem2Keyword T ON P.ID = T.PID 
JOIN Keyword K ON T.KID = K.ID
WHERE K.ID = 2;


SELECT * FROM Problem;
SELECT * FROM Keyword;
SELECT * FROM Problem2Keyword;

BEGIN TRAN 
--DELETE Problem WHERE ID = 1;
DELETE Keyword WHERE ID = 2;

ROLLBACK;

---------------------------------------
--JOIN和UNION：INNER/LEFT/RIGHT/FULL/CROSS以及自连接
--1.

SELECT * FROM Problem
SELECT * FROM [User]

SELECT 
P.Title,
U.UserName
FROM Problem P JOIN [User] U 
ON P.UserID = U.ID 

--2.

SELECT 
P.Title,
U.UserName
FROM Problem P RIGHT JOIN [User] U 
ON P.UserID = U.ID 
WHERE P.Title IS NULL

SELECT * FROM Problem
SELECT * FROM [User]

BEGIN TRAN 
DELETE [User] 
FROM Problem P RIGHT JOIN [User] U 
ON P.UserID = U.ID 
WHERE P.Title IS NULL

ROLLBACK

--3.

USE SSDBtest

SELECT 
U.Id,
U.[Name],
U.InviteBy,
I.Id,
I.[Name]
FROM Student U JOIN Student I 
ON U.InviteBy = I.Id 

--4.

USE TaskSQL

SELECT * FROM Keyword

ALTER TABLE Keyword 
--ADD Superior INT NULL
ADD CONSTRAINT FK_Keyword_Superior_Keyword_Id 
FOREIGN KEY (Superior) 
REFERENCES Keyword (Id)

SELECT 
T.Id,
T.[Name],
W.[Name],
O.[Name]
FROM Keyword T 
LEFT JOIN Keyword W ON T.Superior = W.Id 
LEFT JOIN Keyword O ON W.Superior = O.Id

--5.

SELECT * FROM Problem

CREATE TABLE Suggest 
(
	Id INT NOT NULL CONSTRAINT PK_Suggest_Id PRIMARY KEY,
	Title NVARCHAR(20) NOT NULL,
	Content NTEXT NULL,
	Kind NVARCHAR(20) NULL,
	PublishTime DATETIME NOT NULL,
	Auhthor INT NULL CONSTRAINT FK_Suggest_Auhthor_User_ID FOREIGN KEY REFERENCES [User] (ID)
)

CREATE TABLE Article 
(
	Id INT NOT NULL CONSTRAINT PK_Article_Id PRIMARY KEY,
	Title NVARCHAR(20) NOT NULL,
	Content NTEXT NULL,
	Category INT NULL,
	PublishTime DATETIME NOT NULL,
	Auhthor INT NULL CONSTRAINT FK_Article_Auhthor_User_ID FOREIGN KEY REFERENCES [User] (ID)
)

SELECT Title,UserID,PublishDateTime FROM Problem WHERE UserID = 2 
UNION 
SELECT Title,Auhthor,PublishTime FROM Suggest WHERE Auhthor = 2 
UNION 
SELECT Title,Auhthor,PublishTime FROM Article WHERE Auhthor = 2 
--
ORDER BY PublishDateTime DESC


----------------------------------------
--子查询：独立/相关，以及集合运算
--1.

SELECT * FROM Problem

SELECT UserID,Title,Reward FROM Problem ORDER BY UserID,Reward

SELECT UserID,MIN(Reward) FROM Problem GROUP BY UserID

SELECT UserID,Title,Reward FROM Problem OT
WHERE Reward = (
	SELECT MIN(Reward) FROM Problem IT 
	WHERE OT.UserID = IT.UserID
)

BEGIN TRAN 
DELETE Problem 
WHERE Title IN (
	SELECT Title FROM Problem OT
	WHERE Reward = (
		SELECT MIN(Reward) FROM Problem IT 
		WHERE OT.UserID = IT.UserID
	)
)

ROLLBACK

--2

USE SSDBtest

SELECT * FROM Student

SELECT * FROM Student 
WHERE Id NOT IN (
	SELECT InviteBy FROM Student 
	WHERE InviteBy IS NOT NULL
	GROUP BY InviteBy
)

--3

USE TaskSQL

SELECT * FROM Problem
SELECT * FROM Keyword
SELECT * FROM Problem2Keyword

SELECT 
P.Id,
P.Title,
P.Reward,
T.PID,
T.KID,
K.Id,
K.[Name]
FROM Problem P 
JOIN Problem2Keyword T ON P.Id = T.PID 
JOIN Keyword K ON T.KID = K.Id

SELECT P.Id,COUNT(K.[Name])
FROM Problem P 
JOIN Problem2Keyword T ON P.Id = T.PID 
JOIN Keyword K ON T.KID = K.Id
GROUP BY P.Id

BEGIN TRAN 
UPDATE Problem SET Reward *= 2 
WHERE Id IN (
	SELECT P.Id FROM Problem P 
	JOIN Problem2Keyword T ON P.Id = T.PID 
	JOIN Keyword K ON T.KID = K.Id
	GROUP BY P.Id
	HAVING COUNT(K.[Name]) >= 3
)

ROLLBACK

SELECT * FROM Problem

--4.

SELECT UserID,COUNT(Title) FROM Problem 
GROUP BY UserID

SELECT * FROM [User] U 
LEFT JOIN [Profile] F ON U.ID = F.ID 
WHERE U.ID IN (
	SELECT UserID FROM Problem 
	GROUP BY UserID
	HAVING COUNT(Title) > 3 
)

--5.

SELECT UserID,PublishDateTime,Title FROM Problem ORDER BY UserID,PublishDateTime DESC

SELECT ROW_NUMBER() 
OVER (PARTITION BY UserID 
ORDER BY PublishDateTime DESC) RID,
UserID,PublishDateTime,Title 
FROM Problem 

SELECT * FROM (
	SELECT ROW_NUMBER() 
	OVER (PARTITION BY UserID 
	ORDER BY PublishDateTime DESC) RID,
	UserID,PublishDateTime,Title 
	FROM Problem 
) DP 
WHERE DP.RID = 1 

SELECT UserID,PublishDateTime,Title FROM Problem OT 
WHERE PublishDateTime IN (
	SELECT MAX(PublishDateTime) FROM Problem IT
	WHERE OT.UserID = IT.UserID
)

--6.

SELECT UserID,Title,Reward FROM Problem ORDER BY UserID,Reward

SELECT UserID,Title,Reward FROM Problem OT
WHERE 5 < (
	SELECT MIN(Reward) FROM Problem IT 
	WHERE OT.UserID = IT.UserID
)


------------------------------------------
--表表达式：派生表/CTE/分页查询
--1.

SELECT * FROM Problem

SELECT te.Pyear,te.Pmonth,COUNT(te.Title) FROM (
	SELECT Title,
	YEAR(PublishDateTime) AS Pyear,
	MONTH(PublishDateTime) AS Pmonth
	FROM Problem ) te 
GROUP BY te.Pyear,te.Pmonth
ORDER BY te.Pyear,te.Pmonth

WITH te AS (
	SELECT Title,
	YEAR(PublishDateTime) AS Pyear,
	MONTH(PublishDateTime) AS Pmonth
	FROM Problem )
SELECT te.Pyear,te.Pmonth,COUNT(te.Title) FROM te 
GROUP BY te.Pyear,te.Pmonth
ORDER BY te.Pyear,te.Pmonth

--2.

SELECT * FROM (
	SELECT 
	ROW_NUMBER() OVER (
		PARTITION BY te.Pyear,te.Pmonth 
		ORDER BY te.Pyear,te.Pmonth,te.Reward DESC
	) AS RID,* 
	FROM (
		SELECT	
		YEAR(PublishDateTime) AS Pyear,
		MONTH(PublishDateTime) AS Pmonth,
		Title,
		Reward
		FROM Problem
	) te ) rte
WHERE rte.RID <= 3

WITH te AS (
	SELECT	
	YEAR(PublishDateTime) AS Pyear,
	MONTH(PublishDateTime) AS Pmonth,
	Title,
	Reward
	FROM Problem )
SELECT * FROM (
	SELECT 
	ROW_NUMBER() OVER (
		PARTITION BY te.Pyear,te.Pmonth 
		ORDER BY te.Pyear,te.Pmonth,te.Reward DESC
	) AS RID,* 
	FROM te ) rte
WHERE rte.RID <= 3

WITH 
te AS (
	SELECT	
	YEAR(PublishDateTime) AS Pyear,
	MONTH(PublishDateTime) AS Pmonth,
	Title,
	Reward
	FROM Problem ),
rte AS (
	SELECT 
	ROW_NUMBER() OVER (
		PARTITION BY te.Pyear,te.Pmonth 
		ORDER BY te.Pyear,te.Pmonth,te.Reward DESC
	) AS RID,* 
	FROM te )
SELECT * FROM rte 
WHERE rte.RID <= 3

--3.

WITH 
te AS (
	SELECT	
	UserID,
	YEAR(PublishDateTime) AS Pyear,
	MONTH(PublishDateTime) AS Pmonth,
	Title,
	Reward
	FROM Problem ),
rte AS (
	SELECT 
	ROW_NUMBER() OVER (
		PARTITION BY te.UserID,te.Pyear,te.Pmonth 
		ORDER BY te.UserID,te.Pyear,te.Pmonth,te.Reward DESC
	) AS RID,* 
	FROM te )
SELECT * FROM rte 
WHERE rte.RID <= 3

--4.

SELECT * FROM Problem ORDER BY PublishDateTime

SELECT TOP 3 Title,Reward,PublishDateTime,UserID FROM Problem 
ORDER BY PublishDateTime

SELECT TOP 3 Title,Reward,PublishDateTime,UserID FROM Problem
WHERE ID NOT IN (
	SELECT TOP 3 ID FROM Problem 
	ORDER BY PublishDateTime )
ORDER BY PublishDateTime

SELECT TOP 3 Title,Reward,PublishDateTime,UserID FROM Problem
WHERE ID NOT IN (
	SELECT TOP 6 ID FROM Problem 
	ORDER BY PublishDateTime )
ORDER BY PublishDateTime

---

SELECT ID,Title,Reward,PublishDateTime,UserID FROM Problem 
ORDER BY PublishDateTime

SELECT * FROM (
	SELECT 
	ROW_NUMBER() OVER (
		ORDER BY PublishDateTime ) AS RID,
	ID,Title,Reward,PublishDateTime,UserID FROM Problem ) TE
WHERE TE.RID >= 4 AND TE.RID <= 6

--1--1-3   
--2--4-6
--3--7-9   (pageindex-1)*pagesize+1  --  pageindex*pagesize

---

SELECT ID,Title,Reward,PublishDateTime,UserID FROM Problem 
ORDER BY PublishDateTime
OFFSET 6 ROWS
FETCH NEXT 3 ROWS ONLY

