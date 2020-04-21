USE WorldEvents
GO

SELECT EventName
FROM tblEvent
WHERE (EventName LIKE '%Teletubbies%' OR EventName LIKE '%Pandy%')
ORDER BY EventDate ASC