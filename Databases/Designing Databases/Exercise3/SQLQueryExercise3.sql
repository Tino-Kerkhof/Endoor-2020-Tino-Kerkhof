CREATE DATABASE YourDatabase
go

USE YourDatabase
go

CREATE TABLE Jobs(
	job_id int IDENTITY(1,1) NOT NULL,
	job_title nvarchar(25) NOT NULL,
	min_salary smallmoney NOT NULL,
	max_salary smallmoney NOT NULL,
	CONSTRAINT MX_max_salery CHECK ( max_salary <= 25000.00 ),
	CONSTRAINT PK_job_id PRIMARY KEY(job_id)
)
go