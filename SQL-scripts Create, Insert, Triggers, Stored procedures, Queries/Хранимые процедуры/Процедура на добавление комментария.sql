CREATE PROCEDURE New_Comment (@comment_text NCHAR(100), @user_id tinyint, @video_id tinyint)
AS
IF Exists(SELECT * FROM [User] 
WHERE [User].[User_ID] = @user_id) AND
Exists(SELECT * FROM [Video]
WHERE [Video].Video_ID = @video_id)
INSERT INTO [Comment] VALUES((SELECT ISNULL (MAX([Comment].Comment_ID)+1,1) FROM [Comment]),
@comment_text, GETDATE(), @user_id, @video_id);
ELSE
PRINT ('Неверный ввод данных'); 