CREATE PROCEDURE New_Subscribe (@user_id_subscriber tinyint, @user_id_channel tinyint)
AS
IF Exists(SELECT * FROM [User] 
WHERE [User].[User_ID] = @user_id_subscriber) AND
Exists(SELECT * FROM [User]
WHERE [User].[User_ID] = @user_id_channel) AND 
NOT Exists(SELECT * FROM Subscribe WHERE User_ID_subscriber=@user_id_subscriber AND 
User_ID_channel=@user_id_channel)
INSERT INTO [Subscribe] VALUES(GETDATE(),
(SELECT ISNULL (MAX([Subscribe].Subscriber_ID)+1,1) FROM [Subscribe]),
@user_id_subscriber, @user_id_channel);
ELSE
PRINT ('Ошибка!Подписка невозможна!'); 