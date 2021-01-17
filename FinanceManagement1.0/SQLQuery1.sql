﻿--1. Create DB
CREATE DATABASE QLFinance ON  PRIMARY 
	( NAME = 'QLFinance', 
	FILENAME = 'F:\Công Nghệ Phần Mền\Lap Trinh Windows\DoAnCuoiKy\Database\a\QLFinance.mdf' , 
	SIZE = 3072KB ,
	MAXSIZE = UNLIMITED, 
	FILEGROWTH = 1024KB )
 LOG ON 
	( NAME = 'QLFinance', 
	FILENAME = 'F:\Công Nghệ Phần Mền\Lap Trinh Windows\DoAnCuoiKy\Database\a\QLFinance.ldf' , 
	SIZE = 1024KB , 
	MAXSIZE = 2048KB , 
	FILEGROWTH = 10%);
GO
CREATE TABLE FmAcount
(
	FmUserId int IDENTITY(1,1) PRIMARY KEY,
	FmUser NVARCHAR(52) NOT NULL,
	FmPass NVARCHAR(52) NOT NULL,
	FmName NVARCHAR(100) NOT NULL,
	FmPhone INT NOT NULL
);
GO

CREATE TABLE FmCatelogy
(
	FmCatelogyID INT NOT NULL,
	FmCatelogyName NVARCHAR(52) NOT NULL
);
GO



CREATE TABLE FmIncome
(
	FmUser NVARCHAR(52) NOT NULL,
	FmIncome NVARCHAR(52) NOT NULL,
	FmNote NVARCHAR(52) NOT NULL,
	FmWName NVARCHAR(52) NOT NULL,
	FmCatelogy NVARCHAR(52) NOT NULL

);
GO
CREATE TABLE FmExpense
(
	FmUser NVARCHAR(52) NOT NULL,
	FmExpense NVARCHAR(52) NOT NULL,
	FmNote NVARCHAR(52) NOT NULL,
	FmWName NVARCHAR(52) NOT NULL,
	FmCreatedDate NVARCHAR(52) NOT NULL
);
GO
CREATE TABLE FmWallet
(
	FmWID int IDENTITY(1,1) PRIMARY KEY,
	FmUser NVARCHAR(52) NOT NULL,
	FmWAccount NVARCHAR(52) NOT NULL,
	FmWName NVARCHAR(52) NOT NULL,
	FmWCate NVARCHAR(52) NOT NULL,
	FmWNote NVARCHAR(52) NOT NULL
);
GO
CREATE TABLE FmBudget
(
	FmBID int IDENTITY(1,1) PRIMARY KEY,
	FmUser INT NOT NULL,
	FmCatelogyName NVARCHAR(52) NOT NULL,
	FmVND NVARCHAR(52) NOT NULL,
	FmBName NVARCHAR(52) NOT NULL,
	FmStart DATETIME NULL,
	FmEnd DATETIME NULL
);
GO
select* from FmAcount
USE [master];
GO
ALTER DATABASE [QLFinance] MODIFY FILE ( NAME = QLFinance, NEWNAME = QLFinance_Data );
GO

USE [QLFinance];
GO
SELECT file_id, name AS logical_name, physical_name
FROM sys.database_files