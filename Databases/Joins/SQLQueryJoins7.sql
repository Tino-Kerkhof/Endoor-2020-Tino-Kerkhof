USE WorldEvents
go

SELECT 
	tblEvent.EventName, 
	tblEvent.EventDate, 
	tblCountry.CountryName, 
	tblContinent.ContinentName
FROM     
	tblContinent INNER JOIN
		tblCountry ON tblContinent.ContinentID = tblCountry.ContinentID INNER JOIN
		tblEvent ON tblCountry.CountryID = tblEvent.CountryID
WHERE  
	(tblCountry.CountryName LIKE '%Russia%') OR (tblContinent.ContinentName LIKE '%Antarctic%')