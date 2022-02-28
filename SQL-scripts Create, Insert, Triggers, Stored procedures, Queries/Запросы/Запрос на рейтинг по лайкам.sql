SELECT Video.Video_ID AS ID, Video.Video_name AS Название, 
COUNT([Like].Like_ID) AS Число_лайков
FROM
Video INNER JOIN [Like] ON Video.Video_ID=[Like].Video_ID
GROUP BY Video.Video_ID, Video.Video_name
ORDER BY COUNT([Like].Like_ID) DESC; 
