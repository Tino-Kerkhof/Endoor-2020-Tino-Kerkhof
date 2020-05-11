USE WorldEvents
go

-- show what happened in what country at what date
SELECT 
	-- get country name
	tblCountry.CountryName AS Country, 
	--get event and date
	tblEvent.EventName AS [What happened], 
	tblEvent.EventDate AS [When happened]
FROM     
	-- link country and event through countryID
	tblCountry INNER JOIN tblEvent 
	ON tblCountry.CountryID = tblEvent.CountryID
ORDER BY 
	-- Order by date
	[When happened]