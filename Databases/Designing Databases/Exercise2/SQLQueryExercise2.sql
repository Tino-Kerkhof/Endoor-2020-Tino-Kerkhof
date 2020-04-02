CREATE DATABASE LINKHUB
go

USE LINKHUB
CREATE TABLE Users(
	UserId int IDENTITY(1000,1) PRIMARY KEY,
	UserName nvarchar(25) NOT NULL,
	[Password] nvarchar(255) NOT NULL,
	[Image] varbinary(max),
	Email nvarchar(100) NOT NULL,
	UserBirthDate date
)
CREATE TABLE Categories(
	CategoryCode nchar(3) PRIMARY KEY,
	CategoryName nvarchar(25) NOT NULL,
	[Description] nvarchar(255)
)
go
CREATE TABLE Urls(
	[Url] nvarchar(255) NOT NULL,
	CreationDate datetime NOT NULL DEFAULT getdate(),
	[Description] nvarchar(max),
	UserId int FOREIGN KEY REFERENCES Users(UserId) NOT NULL,
	CategoryCode nchar(3) FOREIGN KEY REFERENCES Categories(CategoryCode) NOT NULL,
	PRIMARY KEY(UserId, CategoryCode, [Url])
)
go

INSERT INTO Users(
	UserName, [Password], Email, UserBirthDate
)
VALUES
	('Beppie', 'Beppie123', 'Beppie@home.nl', '1930-12-20'),
	('Kees de Graaf', 'xHye5S7r', 'KeesdeGraaf@home.nl', '1928-04-30'),
	('Koen de Graaf', 'URLshebikhier', 'KoendeGraaf@home.nl', '1954-01-15');

INSERT INTO Categories(
	CategoryCode, CategoryName, [Description]
)
VALUES
	('KAT', 'Katten videos', 'De allerliefste katten vind je hier.'),
	('BVV', 'Bouwvakkers vereniging', 'Stukjes van de bouwvakkersvereniging'),
	('BRI', 'Brijen', 'Kunstwerken van onze brijgroep'),
	('WW2', 'Oorlogsverhalen', 'Forumposts van kammaraden'),
	('BVA', 'Boodschappen voordeel', 'Leuke aanbiedingen waar we geld op kunnen besparen');
go

INSERT INTO Urls(
	CreationDate, [Description], UserId, CategoryCode,
	[Url]
)
VALUES
	('2019-03-23 12:35:29.123', 'Schattige katjes 1', '1000', 'KAT',
	'www.schattigkatje1.nl/3htj49k3'),
	('2019-03-23 12:36:40.123', 'Schattige katjes 2', '1000', 'KAT',
	'www.schattigkatjesupercute.nl/kroelepoep'),
	('2019-04-21 12:35:29.123', 'Schattige katjes 4', '1000', 'KAT',
	'www.schattigkatjesupercute.nl/poepisnoet'),
	('2018-07-26 20:45:29.123', 'feesie!!!', '1002', 'BVV',
	'www.Bouwvakkersvereniging.nl/40jaar'),
	('2018-03-23 12:34:50.003', 'Brijpatroon koetje', '1001', 'BRI',
	'www.samenbrijen.nl/koetje'),
	('2018-05-24 14:35:29.123', 'Bennie in Frankrijk', '1001', 'WW2',
	'www.WWIIforum.nl/deslagomchampagne'),
	('2020-03-23 12:35:40.123', 'Schattige katjes toeter', '1002', 'KAT',
	'www.schattigkatje1.nl/4hgh6ik3'),
	('2018-11-01 23:35:29.123', 'Kattengrint in de aanbieding', '1001', 'BVA',
	'www.uwkattengoedverzorgd.nl'),
	('2019-04-25 12:36:40.123', 'Bennie in Groot Bretanië', '1001', 'WW2',
	'www.WWIIforum.nl/10dagenvoordday'),
	('2020-01-14 14:36:40.123', 'D-day', '1001', 'WW2',
	'www.WWIIforum.nl/dday');

go
