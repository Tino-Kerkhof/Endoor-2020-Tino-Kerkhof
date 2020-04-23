USE WorldEvents
GO

DECLARE @myBirthDate Date;
SET @myBirthDate = '1991-08-01';

SELECT 
EventName,
CONVERT (VARCHAR(11), EventDate, 106) AS [Event date],
DATEDIFF(day, EventDate, @myBirthDate) AS [Days offset],
ABS(DATEDIFF(day, EventDate, @myBirthDate)) AS [Days difference]

FROM tblEvent
ORDER BY [Days difference]
