USE DoctorWho
go

SELECT 
	tblAuthor.AuthorName, 
	tblEpisode.Title
FROM     
	tblEpisode INNER JOIN
		tblEpisodeEnemy ON tblEpisode.EpisodeId = tblEpisodeEnemy.EpisodeId INNER JOIN
        tblEnemy ON tblEpisodeEnemy.EnemyId = tblEnemy.EnemyId INNER JOIN
        tblAuthor ON tblEpisode.AuthorId = tblAuthor.AuthorId
WHERE  
	(tblEnemy.EnemyName LIKE '%Daleks%')