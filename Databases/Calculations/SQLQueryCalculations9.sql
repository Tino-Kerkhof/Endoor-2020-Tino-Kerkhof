USE WorldEvents
GO

SELECT 
EventName,
EventDate,
DATENAME (weekday, EventDate) AS [Day of Week],
DATEPART (day, EventDate) AS [Day number]
FROM tblEvent
WHERE ((DATENAME (weekday, EventDate) = 'Thursday' AND DATEPART (day, EventDate) = 12) OR
	   (DATENAME (weekday, EventDate) = 'Friday'   AND DATEPART (day, EventDate) = 13) OR
	   (DATENAME (weekday, EventDate) = 'Saturday' AND DATEPART (day, EventDate) = 14))
ORDER BY EventDate ASC
