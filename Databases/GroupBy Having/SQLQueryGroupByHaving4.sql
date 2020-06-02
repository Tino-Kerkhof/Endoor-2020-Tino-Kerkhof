USE DoctorWho
GO

SELECT 
	YEAR(tblEpisode.EpisodeDate) AS [Episode year],
	tblEnemy.EnemyName AS [Enemy Name], 
	COUNT(tblEpisode.EpisodeId) AS [Number of Episodes]
FROM     
	tblEnemy INNER JOIN
		tblEpisodeEnemy ON tblEnemy.EnemyId = tblEpisodeEnemy.EnemyId INNER JOIN
		tblEpisode ON tblEpisodeEnemy.EpisodeId = tblEpisode.EpisodeId INNER JOIN
		tblDoctor ON tblEpisode.DoctorId = tblDoctor.DoctorId
WHERE YEAR(tblDoctor.BirthDate) < 1970
GROUP BY 
	YEAR(tblEpisode.EpisodeDate), 
	tblEnemy.EnemyName
HAVING COUNT(tblEpisode.EpisodeId) > 1
ORDER BY [Number of Episodes] DESC
