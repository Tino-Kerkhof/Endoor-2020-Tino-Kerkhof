use DoctorWho
go

SELECT 
	tblAuthor.AuthorName, 
	tblEpisode.Title, 
	tblDoctor.DoctorName, 
	tblEnemy.EnemyName,
	(LEN(tblAuthor.AuthorName) + LEN(tblEpisode.Title) + 
		LEN(tblDoctor.DoctorName) + LEN(tblEnemy.EnemyName)) AS [Total Length]
FROM     
	tblDoctor INNER JOIN
        tblEpisode ON tblDoctor.DoctorId = tblEpisode.DoctorId INNER JOIN
        tblAuthor ON tblEpisode.AuthorId = tblAuthor.AuthorId INNER JOIN
        tblEpisodeEnemy ON tblEpisode.EpisodeId = tblEpisodeEnemy.EpisodeId INNER JOIN
        tblEnemy ON tblEpisodeEnemy.EnemyId = tblEnemy.EnemyId
WHERE 
	LEN(AuthorName) + LEN(Title) + LEN(DoctorName) + LEN(EnemyName) <= 40
ORDER BY
	[Total Length] DESC