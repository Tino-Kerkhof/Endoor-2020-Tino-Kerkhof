USE DoctorWho
go

SELECT 
	tblEpisode.Title, 
	tblEpisode.EpisodeType, 
	tblAuthor.AuthorName
FROM     
	tblAuthor INNER JOIN tblEpisode 
		ON tblAuthor.AuthorId = tblEpisode.AuthorId
WHERE  
	tblEpisode.EpisodeType LIKE '%special%'
ORDER BY 
	tblEpisode.Title