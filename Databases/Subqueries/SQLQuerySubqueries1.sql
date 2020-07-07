USE WorldEvents
GO

SELECT 
	tblEvent.EventName, 
	tblEvent.EventDate, 
	tblCountry.CountryName
FROM     
	tblCountry INNER JOIN
		tblEvent ON tblCountry.CountryID = tblEvent.CountryID
WHERE
	EventDate > (
	SELECT 
		MAX(tblEvent.EventDate)
	FROM     
		tblCountry INNER JOIN
			tblEvent ON tblCountry.CountryID = tblEvent.CountryID
	WHERE tblCountry.CountryID = 21)
ORDER BY 
	tblEvent.EventDate DESC

--WHERE
--Event date > (
--SELECT MAX(Event date)
--FROM table of events
--WHERE country id = 21
--)
-- ORDER BY
--Event date (descending)
