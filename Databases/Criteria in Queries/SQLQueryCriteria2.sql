USE WorldEvents
GO

SELECT EventName, EventDetails, EventDate
FROM tblEvent
WHERE ((CountryID IN (8, 12, 30, 35) OR EventDetails = 'water' OR CategoryID = 4) AND EventDate >= '1970-01-01')
ORDER BY EventDate ASC