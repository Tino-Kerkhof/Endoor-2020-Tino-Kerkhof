USE WorldEvents
GO

SELECT 
ContinentName, 
Summary,

ISNULL(Summary, 'No summary') AS [Using ISNULL],	 
COALESCE(Summary, 'No summary') AS [Using COALESCE], 
CASE
	WHEN Summary IS NULL THEN 'No summary'
	ELSE Summary
END AS [Using CASE]
FROM tblContinent
ORDER BY ContinentID ASC

-- ISNULL is good if you only expect null and want input from only one column, like here.
-- COALESCE is good if you want input from multiple columns of which multiple can be null.
-- CASE is good if you want input from one or more columns and want to change multiple  
--    inputs or anything other than null