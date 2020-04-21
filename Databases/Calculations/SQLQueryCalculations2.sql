USE WorldEvents
GO

DECLARE @WalesSize int;
SET @WalesSize = 20761;

SELECT 
[Country],
[KmSquared],
([KmSquared] / @WalesSize) AS WalesUnits,
([KmSquared] % @WalesSize) AS AreaLeftOver,
CASE
	WHEN ([KmSquared] / @WalesSize) < 1
	THEN 'Smaller than Wales'
	ELSE CAST ([KmSquared] / @WalesSize AS NVARCHAR(6)) + ' x Wales plus ' + 
	CAST ([KmSquared] % @WalesSize AS NVARCHAR(6)) + ' sq. km.'
	END AS [Wales Comparison]

FROM CountriesByArea
ORDER BY ABS(((([KmSquared] / @WalesSize) - 1) * @WalesSize) + ([KmSquared] % @WalesSize))
