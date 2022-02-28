CREATE PROCEDURE Number_of_videos_in_playlists
AS DECLARE @a INT --счётчик
SET @a = (SELECT COUNT(*) FROM Playlist)
WHILE (@a > 0) BEGIN EXECUTE Number_of_videos_realvalue @a
SET @a=@a-1
  IF @a < 0
      BREAK
   ELSE
      CONTINUE
END
PRINT 'Цикл закончил работу-теперь в столбце таблицы Playlist содержится реальные количества видеозаписей!' 
