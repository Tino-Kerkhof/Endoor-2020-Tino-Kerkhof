use WorldEvents
go

SELECT 
	tblEvent.EventDate, 
	tblEvent.EventName, 
	tblCategory.CategoryName
FROM     
	tblCategory 
		FULL OUTER JOIN tblEvent 
		ON tblCategory.CategoryID = tblEvent.CategoryID
WHERE 
	tblEvent.EventName IS NULL
ORDER BY
	tblEvent.EventDate DESC