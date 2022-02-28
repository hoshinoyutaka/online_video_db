CREATE TRIGGER Number_of_videos_updated ON Video_Playlist AFTER INSERT
AS
DECLARE @a INT SET @a =  (SELECT Playlist_ID FROM inserted);
UPDATE Playlist SET  Number_of_videos = Number_of_videos + 1 WHERE Playlist.Playlist_ID = @a; 