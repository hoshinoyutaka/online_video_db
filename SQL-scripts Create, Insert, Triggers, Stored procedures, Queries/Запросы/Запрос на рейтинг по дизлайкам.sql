SELECT Video.Video_ID AS ID, Video.Video_name AS ��������, 
COUNT(Dislike.Disike_ID) AS �����_���������
FROM
Video INNER JOIN Dislike ON Video.Video_ID=Dislike.Video_ID
GROUP BY Video.Video_ID, Video.Video_name
ORDER BY COUNT(Dislike.Disike_ID) DESC; 
