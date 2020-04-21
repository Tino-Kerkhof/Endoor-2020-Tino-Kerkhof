USE WorldEvents
GO

SELECT EventName, EventDate
FROM tblEvent
WHERE (EventDate >= '2005-02-01' AND EventDate < '2005-03-01')
ORDER BY EventDate ASC