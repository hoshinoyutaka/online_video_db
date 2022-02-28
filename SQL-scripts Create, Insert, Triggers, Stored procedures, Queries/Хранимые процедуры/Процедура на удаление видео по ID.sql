CREATE PROCEDURE Video_deleted (@video_id tinyint)
AS
DELETE FROM Video WHERE Video_ID=@video_id; 