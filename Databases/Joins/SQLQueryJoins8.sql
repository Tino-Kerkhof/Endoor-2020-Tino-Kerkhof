USE WorldEvents
GO

SELECT 
	tblCountry.CountryName, 
	tblEvent.EventName
FROM     
	tblCountry FULL OUTER JOIN
		tblEvent ON tblCountry.CountryID = tblEvent.CountryID
WHERE  
	(tblEvent.EventName IS NULL)