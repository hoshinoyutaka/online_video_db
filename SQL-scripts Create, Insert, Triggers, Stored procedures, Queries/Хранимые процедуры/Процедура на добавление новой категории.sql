CREATE PROCEDURE New_category (@category_name NCHAR(25))
AS
INSERT INTO Category VALUES((SELECT ISNULL (MAX(Category_ID)+1,1) FROM Category), @category_name); 
