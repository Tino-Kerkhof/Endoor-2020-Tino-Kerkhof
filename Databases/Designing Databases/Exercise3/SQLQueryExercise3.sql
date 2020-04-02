CREATE DATABASE YourDatabase
go

USE YourDatabase
CREATE TABLE Jobs(
	job_id int IDENTITY(1,1) PRIMARY KEY,
	job_title nvarchar(25) NOT NULL,
	min_salary 
	max_salary
)