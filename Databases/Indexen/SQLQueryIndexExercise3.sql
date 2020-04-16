--Exercise 2 (per ongeluk verkeerde bestand ingeleverd, tijdens het proberen te 
-- verbeteren van exercise 1)

--USE AdventureWorksLT2014
--GO

--CREATE INDEX IDX_CompanyName
--ON SalesLT.Customer (CompanyName)

--CREATE INDEX IDX_LastNameFirstName
--ON SalesLT.Customer (LastName,FirstName)

--CREATE INDEX IDX_ModelCategory
--ON SalesLT.Product (ProductCategoryID, ProductModelID)

-- Exercise 3
--Table Actor
USE sakila
go

CREATE INDEX IDX_last_name_first_name
ON dbo.actor (last_name, first_name)

CREATE INDEX IDX_last_name
ON dbo.actor (last_name)

-- Table Film
CREATE INDEX IDX_title
ON dbo.film (title)

CREATE INDEX IDX_original_language_id_language_id
ON dbo.film (original_language_id, language_id)
go