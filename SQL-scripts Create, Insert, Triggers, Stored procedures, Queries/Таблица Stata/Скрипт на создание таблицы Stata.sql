CREATE TABLE Stata (
Video_ID tinyint NOT NULL,
Stata_likes tinyint,
Stata_dislikes tinyint,
Stata_views tinyint,
FOREIGN KEY ([Video_ID]) REFERENCES [Video]([Video_ID])
		ON DELETE CASCADE
		ON UPDATE CASCADE
) 