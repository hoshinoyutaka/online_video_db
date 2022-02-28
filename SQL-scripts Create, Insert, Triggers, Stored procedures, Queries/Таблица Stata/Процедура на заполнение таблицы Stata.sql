CREATE PROCEDURE Insert_into_stata
AS DECLARE @a INT --счётчик
SET @a = (SELECT COUNT(*) FROM Video)
WHILE (@a > 0) BEGIN INSERT INTO Stata VALUES (
(SELECT Video_ID FROM Video WHERE Video_ID=@a),
(SELECT COUNT([Like].Like_ID)
FROM Video INNER JOIN [Like] ON Video.Video_ID=[Like].Video_ID WHERE Video.Video_ID=@a),
(SELECT COUNT([Dislike].Disike_ID)
FROM Video INNER JOIN [Dislike] ON Video.Video_ID=[Dislike].Video_ID WHERE Video.Video_ID=@a),
(SELECT COUNT([View].View_ID)
FROM Video INNER JOIN [View] ON Video.Video_ID=[View].Video_ID WHERE Video.Video_ID=@a))
SET @a=@a-1
  IF @a < 0
      BREAK
   ELSE
      CONTINUE
END
PRINT 'Цикл закончил работу-теперь в таблице Stata содержится совокупная информация по всем видео' 