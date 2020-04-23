USE WorldEvents
GO

SELECT 
EventName,
(DATENAME(weekday, EventDate) + ' ' + DATENAME(day, EventDate) +
CASE
	WHEN DATENAME(day, EventDate) = 1 THEN 'st '
	WHEN DATENAME(day, EventDate) = 2 THEN 'nd '
	WHEN DATENAME(day, EventDate) = 3 THEN 'rd '
	WHEN DATENAME(day, EventDate) = 21 THEN 'st '
	WHEN DATENAME(day, EventDate) = 22 THEN 'nd '
	WHEN DATENAME(day, EventDate) = 23 THEN 'rd '
	WHEN DATENAME(day, EventDate) = 31 THEN 'st '
	ELSE 'th '
END
+ DATENAME(month, EventDate) + ' ' + DATENAME(year, EventDate)) AS [Full date]
FROM tblEvent
ORDER BY EventDate ASC
