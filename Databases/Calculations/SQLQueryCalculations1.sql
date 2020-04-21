USE WorldEvents
GO

SELECT EventName, LEN(EventName) AS [Length of Name]
FROM tblEvent
WHERE LEN(EventName) <= 8
ORDER BY LEN(EventName) ASC
