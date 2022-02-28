CREATE PROCEDURE Number_of_videos_realvalue @playlist_id INT
AS DECLARE @number INT, @title NCHAR 
SET @title=(SELECT Playlist.Playlist_title FROM Playlist WHERE Playlist_ID=@playlist_id)
SET @number=(SELECT COUNT(Video_Playlist.Video_ID) FROM Video_Playlist
WHERE Video_Playlist.Playlist_ID=@playlist_id)
UPDATE Playlist 
SET Number_of_videos=@number WHERE Playlist_ID=@playlist_id; 
