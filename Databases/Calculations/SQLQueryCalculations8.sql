USE WorldEvents
GO

Declare @MyBirthYear nvarchar(4);
SET @MyBirthYear = '1991';

SELECT 
EventName, 
EventDate AS NotFormatted,
FORMAT (EventDate, 'dd/MM/yyyy') AS UsingFormat,
CONVERT (CHAR(10), EventDate, 103) AS UsingConvert
FROM tblEvent
WHERE EventDate LIKE (@MyBirthYear + '%')
ORDER BY EventDate ASC
