-- create new table to hold rows
USE DoctorWho
CREATE TABLE tblProductionCompany(
	ProductionCompanyId int IDENTITY(1,1) PRIMARY KEY,
	ProductionCompanyName nvarchar(100) NOT NULL,
	Abbriviation nvarchar(15)
)
go
-- insert 2 new rows
INSERT INTO tblProductionCompany(
	ProductionCompanyName,
	Abbriviation
) 
VALUES 
	('British Broadcasting Assosiation', 'BBC'),
	('Canadian Broadcasting Assosiation', 'CBC');
go