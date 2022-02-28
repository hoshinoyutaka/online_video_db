SELECT Playlist.Playlist_ID, Playlist.Playlist_title, COUNT(Video_Playlist.Video_ID) AS Количество_искомых_видео
FROM Playlist INNER JOIN (Video_Playlist INNER JOIN Video ON Video_Playlist.Video_ID=Video.Video_ID)
ON Playlist.Playlist_ID=Video_Playlist.Playlist_ID
WHERE Video.Privacy_ID=1 AND Video.Video_timestamp BETWEEN '2010/01/01' AND '2017/01/01'
GROUP BY Playlist.Playlist_ID, Playlist.Playlist_title
ORDER BY 3 DESC; 