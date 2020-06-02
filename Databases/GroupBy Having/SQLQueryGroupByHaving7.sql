USE WorldEvents
GO

SELECT 
	tblContinent.ContinentName AS [Continent name],
	tblCountry.CountryName AS [Country name],
	COUNT(tblEvent.EventID) AS [Number of events]
FROM     
	tblContinent INNER JOIN
		tblCountry ON tblContinent.ContinentID = tblCountry.ContinentID INNER JOIN
		tblEvent ON tblCountry.CountryID = tblEvent.CountryID
WHERE (tblContinent.ContinentName != 'Europe')
GROUP BY 
	tblContinent.ContinentName,
	tblCountry.CountryName
HAVING COUNT(tblEvent.EventID) >= 5
ORDER BY [Country name] ASC