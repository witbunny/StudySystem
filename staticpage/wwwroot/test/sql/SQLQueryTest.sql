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