USE WorldEvents
GO

SELECT 
	tblCountry_outer.CountryName
	,count(tblEvent_outer.EventID) AS NumberOfEvents
FROM     
	tblEvent AS tblEvent_outer INNER JOIN
			tblCountry AS tblCountry_outer ON tblEvent_outer.CountryID = tblCountry_outer.CountryID
WHERE (
	SELECT 
		count(tblEvent_inner.EventID) AS NumberOfEvents
	FROM     
		tblEvent AS tblEvent_inner INNER JOIN
			tblCountry AS tblCountry_inner ON tblEvent_inner.CountryID = tblCountry_inner.CountryID
	WHERE (tblEvent_inner.CountryId = tblCountry_outer.CountryId)
	GROUP BY
		tblEvent_inner.CountryID) > 8
GROUP BY 
	tblCountry_outer.CountryID
	,tblCountry_outer.CountryName
ORDER BY
	tblCountry_outer.CountryName ASC