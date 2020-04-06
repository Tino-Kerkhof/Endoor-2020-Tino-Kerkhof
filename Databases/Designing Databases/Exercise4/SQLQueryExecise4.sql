CREATE DATABASE STUDENT
GO
USE STUDENT
GO

CREATE TABLE [dbo].[Student](
 [Studentnummer] [char](7) PRIMARY KEY,
 [Voornaam] [nvarchar](25) NOT NULL,
 [Tussenvoegsels] [nvarchar](15) NULL,
 [Achternaam] [nvarchar](100) NOT NULL,
 [Geboortedatum] [date] NOT NULL,
 [Woonplaats] [nvarchar](25) NOT NULL DEFAULT 'Hengelo',
)
GO

ALTER TABLE [dbo].[Student]
	ADD [EmailAdress] [nvarchar](60) NOT NULL DEFAULT 'example@domain.com';