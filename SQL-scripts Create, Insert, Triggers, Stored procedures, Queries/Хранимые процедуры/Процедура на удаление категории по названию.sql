CREATE PROCEDURE Category_deleted (@category_name nchar(20))
AS
DELETE FROM Category WHERE Category_title=@category_name; 