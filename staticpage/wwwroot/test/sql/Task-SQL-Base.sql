
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