USE WorldEvents
GO

SELECT 
	COUNT(tblEvent.EventID) AS [Number of Events],
	MAX(tblEvent.EventDate) AS [Last Date],
	MIN(tblEvent.EventDate) AS [First Date]
FROM tblEvent
