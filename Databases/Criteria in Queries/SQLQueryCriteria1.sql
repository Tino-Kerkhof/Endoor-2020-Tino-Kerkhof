USE WorldEvents
GO

SELECT EventName, EventDate
FROM tblEvent
WHERE CategoryID = 11
ORDER BY EventDate ASC