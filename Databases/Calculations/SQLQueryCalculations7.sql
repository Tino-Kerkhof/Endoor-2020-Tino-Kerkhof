USE WorldEvents
GO

SELECT 
CountryName, 
CASE
	WHEN ContinentID IN (1,3) THEN 'Eurasia'
	WHEN ContinentID IN (5,6) THEN 'Americas'
	WHEN ContinentID IN (2,4) THEN 'Somewhere hot'
	WHEN ContinentID = 7 THEN 'Somewhere Cold'
	ELSE 'Somewhere Else'
END AS CountryLocation
FROM tblCountry
ORDER BY CountryLocation DESC
