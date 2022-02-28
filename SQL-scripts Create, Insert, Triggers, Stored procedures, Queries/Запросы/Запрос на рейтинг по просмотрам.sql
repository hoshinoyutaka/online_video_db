SELECT Video.Video_ID AS ID, Video.Video_name AS Название, 
COUNT([View].View_ID) AS Число_просмотров
FROM
Video INNER JOIN [View] ON Video.Video_ID=[View].Video_ID
GROUP BY Video.Video_ID, Video.Video_name
ORDER BY COUNT([View].View_ID) DESC;
 