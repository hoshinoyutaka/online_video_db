ALTER TABLE [User]
ADD User_status char(10) CHECK (User_status=N'User' OR User_status=N'Admin'); 
