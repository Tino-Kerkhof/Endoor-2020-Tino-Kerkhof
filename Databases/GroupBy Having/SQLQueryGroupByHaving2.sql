USE DoctorWho
GO

SELECT 
	tblAuthor.AuthorName AS [AuthorName],
	tblDoctor.DoctorName AS [DoctorName],
	COUNT(tblEpisode.EpisodeId) AS [Number of Episodes]
FROM     
	tblAuthor INNER JOIN
		tblEpisode ON tblAuthor.AuthorId = tblEpisode.AuthorId INNER JOIN
		tblDoctor ON tblEpisode.DoctorId = tblDoctor.DoctorId
GROUP BY 
	tblAuthor.AuthorName, 
	tblDoctor.DoctorName
HAVING COUNT(tblEpisode.EpisodeId) >= 5
ORDER BY [Number of Episodes] DESC
