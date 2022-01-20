UPDATE StudentScore SET Score = 92 
WHERE Sname = 'ZL' AND Major = 'JAVA'

SELECT Score FROM StudentScore WHERE Id > 10

SELECT Score FROM StudentScore WHERE Id = 9

SELECT * FROM StudentScore

--------------------------------------------------

SELECT * FROM [User] WHERE UserName = 'Scorpio' AND [Password] = 'aa123456'

SELECT [Password] FROM [User] WHERE UserName = 'Scor' OR 1=1 --'

INSERT [Message] (FromUser, ToUser, Content) VALUES ('1', '2', '3');
--SELECT @@IDENTITY
SELECT SCOPE_IDENTITY()

SELECT * FROM [Message]

SELECT * FROM Credit

UPDATE Credit SET Points += 1 
WHERE Id = 1 
AND UserID = 1 
AND Category = 1