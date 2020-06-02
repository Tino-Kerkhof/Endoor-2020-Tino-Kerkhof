USE DoctorWho
GO

SELECT 
	tblAuthor.AuthorName AS [Author Name], 
	COUNT(tblEpisode.EpisodeId) AS [Number of Episodes], 
	MIN(tblEpisode.EpisodeDate) AS [First Episode], 
	MAX(tblEpisode.EpisodeDate) AS [Last Episode]
FROM     
	tblAuthor INNER JOIN
		tblEpisode ON tblAuthor.AuthorId = tblEpisode.AuthorId
GROUP BY tblAuthor.AuthorName
ORDER BY [Number of Episodes] DESC
