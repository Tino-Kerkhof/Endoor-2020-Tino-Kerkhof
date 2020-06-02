USE WorldEvents
GO

SELECT 
	(CONVERT(nvarchar, (1 + (year(EventDate) - 1) / 100)) + 
        CASE
            WHEN (1 + (year(EventDate) - 1) / 100) % 100 IN (11,12,13) THEN 'th' --first checks for exception
            WHEN (1 + (year(EventDate) - 1) / 100) % 10 = 1 THEN 'st'
            WHEN (1 + (year(EventDate) - 1) / 100) % 10 = 2 THEN 'nd'
            WHEN (1 + (year(EventDate) - 1) / 100) % 10 = 3 THEN 'rd'
            ELSE 'th' --works for num % 10 IN (4,5,6,7,8,9,0)
        END +
		' Century') AS Century, 
	COUNT(EventID) AS [Number of events]
FROM tblEvent
GROUP BY CUBE((1 + (year(EventDate) - 1) / 100))
ORDER BY Century ASC