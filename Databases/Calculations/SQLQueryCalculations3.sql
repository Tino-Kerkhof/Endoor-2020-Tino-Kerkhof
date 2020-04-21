USE WorldEvents
GO

SELECT 
(EventName + ' (category ' + CAST( CategoryID AS NVARCHAR(3)) + ')') AS [EventName (category)]
FROM tblEvent
WHERE CountryID = 1