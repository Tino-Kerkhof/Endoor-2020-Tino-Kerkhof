use DoctorWho
go

SELECT 
	tblDoctor.DoctorName, 
	tblEpisode.Title
FROM     
	tblDoctor INNER JOIN
		tblEpisode ON tblDoctor.DoctorId = tblEpisode.DoctorId
WHERE  
	YEAR(tblEpisode.EpisodeDate) = 2010
ORDER BY 
	tblEpisode.EpisodeDate