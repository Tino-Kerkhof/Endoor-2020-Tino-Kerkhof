USE WorldEvents
GO

SELECT EventName
FROM tblEvent
WHERE (CategoryID <> 14 AND EventDetails LIKE '%Train%')
ORDER BY EventDate ASC

SELECT EventName
FROM tblEvent
WHERE (CountryID = 13 AND NOT EventDetails LIKE '%Space%' AND NOT EventName LIKE '%Space%')
ORDER BY EventDate ASC

SELECT EventName
FROM tblEvent
WHERE (CategoryID IN (5, 6) AND NOT EventDetails LIKE '%Death%' AND NOT EventDetails LIKE '%war%')
ORDER BY EventDate ASC