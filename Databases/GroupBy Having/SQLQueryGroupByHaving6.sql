USE WorldEvents
GO

SELECT 
	LEFT(tblCategory.CategoryName, 1) AS [Category initial], 
	COUNT(tblEvent.EventID) AS [Number of events], 
	CAST(AVG(CONVERT(decimal, LEN(tblEvent.EventName))) AS numeric(5,2)) AS [Average event name length]
FROM     
	tblCategory INNER JOIN
		tblEvent ON tblCategory.CategoryID = tblEvent.CategoryID
GROUP BY LEFT(tblCategory.CategoryName, 1)
ORDER BY [Category initial] ASC