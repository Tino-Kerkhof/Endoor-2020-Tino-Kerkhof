USE WorldEvents
GO

SELECT 
EventName,
EventDate,
CHARINDEX('this', EventDetails, 1)  AS ThisPosition,
CHARINDEX('that', EventDetails, 1)  As ThatPosition,
(CHARINDEX('that', EventDetails, 1) - CHARINDEX('this', EventDetails, 1)) As Offset
FROM tblEvent
WHERE ((CHARINDEX('that', EventDetails, 1) - CHARINDEX('this', EventDetails, 1)) > 0 
	AND CHARINDEX('this', EventDetails, 1) > 0)
ORDER BY (CHARINDEX('that', EventDetails, 1) - CHARINDEX('this', EventDetails, 1))