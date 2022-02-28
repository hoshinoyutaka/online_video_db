CREATE PROCEDURE New_User (@user_nickname NCHAR(25), @user_email NCHAR(25), @user_password NCHAR(25),
@user_surname NCHAR(25), @user_name NCHAR(25), @user_country NCHAR(25), @user_phone NCHAR(25), 
@user_picture NCHAR(255), @user_status nchar(10))
AS
IF Exists(SELECT * FROM [User] WHERE [User].User_nickname = @user_nickname)
PRINT ('Такой никнейм уже существует')
ELSE
IF Exists(SELECT * FROM [User] WHERE [User].User_email = @user_email)
PRINT ('Такая почта уже зарегистрирована')
ELSE
INSERT INTO [User] VALUES(@user_nickname, @user_email, @user_password,
@user_surname, @user_name, @user_country, @user_phone, @user_picture, 
(SELECT ISNULL (MAX([User].[User_ID])+1,1) FROM [User]), @user_status);
 