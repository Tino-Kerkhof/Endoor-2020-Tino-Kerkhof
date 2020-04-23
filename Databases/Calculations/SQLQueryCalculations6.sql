USE WorldEvents
GO

SELECT 
EventName,
CASE
	WHEN EventName LIKE '[AEIOU]%[AEIOU]' THEN 'Begins and ends with vowel'
	ELSE 'Same letter'
END AS Verdict
FROM tblEvent
WHERE (EventName LIKE '[AEIOU]%[AEIOU]' OR LEFT(EventName, 1) = RIGHT(EventName, 1))
ORDER BY EventDate

SELECT 
EventName,
CASE
	WHEN EventName LIKE '[AEIOU]%[AEIOU]' THEN 'Begins and ends with same vowel'
	ELSE 'Same letter'
END AS Verdict
FROM tblEvent
WHERE (EventName LIKE '[AEIOU]%[AEIOU]' AND LEFT(EventName, 1) = RIGHT(EventName, 1))
ORDER BY EventDate
