EXECUTE New_Video N'House of Cards Season 5 Official Trailer [HD] Netflix',N'"The American people dont know whats best for them.... I do." House of Cards Season 5 is now streaming on Netflix.',
 N'https://st.kp.yandex.net/images/film_big/581937.jpg', 150, 6, 1,N'https://www.youtube.com/watch?v=UW8Zyt8SF_U'
SELECT * FROM Video;
INSERT INTO [Like] VALUES(GETDATE(), (SELECT ISNULL (MAX([Like].Like_ID)+1,1) FROM [Like]),201,121)
SELECT * FROM [Like];
INSERT INTO [Dislike] VALUES(GETDATE(), (SELECT ISNULL (MAX([Dislike].Disike_ID)+1,1) FROM [Dislike]),121,201)
SELECT * FROM Dislike;
INSERT INTO [View] VALUES((SELECT ISNULL (MAX([View].View_ID)+1,1) FROM [View]),GETDATE(), 121,201)
SELECT * FROM [View]; 