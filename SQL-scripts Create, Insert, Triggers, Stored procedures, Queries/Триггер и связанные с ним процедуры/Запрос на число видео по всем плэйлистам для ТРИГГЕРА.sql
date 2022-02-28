SELECT Playlist_title AS Название_плэйлиста, COUNT(Video_Playlist.Video_ID) AS Количество_видео FROM
Playlist INNER JOIN (Video_Playlist INNER JOIN Video 
ON Video.Video_ID=Video_Playlist.Video_ID)
ON Playlist.PLaylist_ID=Video_Playlist.Playlist_ID
GROUP BY Playlist_title
ORDER BY COUNT(Video_Playlist.Video_ID) DESC; 