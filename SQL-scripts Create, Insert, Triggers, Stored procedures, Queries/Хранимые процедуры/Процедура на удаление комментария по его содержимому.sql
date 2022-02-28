CREATE PROCEDURE Comment_deleted (@comment_text nchar(20))
AS
DELETE FROM Comment WHERE Comment_text LIKE '%'+@comment_text+'%'; 