CREATE PROCEDURE New_Video (@video_name NCHAR(100), @video_description NCHAR(255), @video_cover NCHAR(255), @user_id tinyint, @category_id tinyint, @privacy_id tinyint, @video_link NCHAR(255)) 
AS
IF Exists(SELECT * FROM [Category] 
WHERE [Category].Category_ID = @category_id) 
AND 
   Exists(SELECT * FROM [Privacy] WHERE [Privacy].Privacy_ID = @privacy_id) 
AND
   Exists(SELECT * FROM [User] WHERE [User].[User_ID] = @user_id)
INSERT INTO [Video] VALUES (
@video_name, @video_description, GETDATE(), @video_cover,
(SELECT ISNULL (MAX([Video].[Video_ID])+1,1) FROM [Video]), 
@user_id, @category_id, @privacy_id, @video_link 
)
ELSE 
PRINT ('Неверный ввод данных');
 