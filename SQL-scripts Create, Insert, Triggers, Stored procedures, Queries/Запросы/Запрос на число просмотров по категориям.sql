--Среднее число просмотров по видео каждой категории
SELECT Category.Category_ID, Category.Category_title, COUNT([View].View_ID) AS Количество_просмотров
FROM [View] INNER JOIN ( Video INNER JOIN Category ON Video.Category_ID=Category.Category_ID)
ON [View].Video_ID=Video.Video_ID
GROUP BY Category.Category_ID, Category.Category_title
ORDER BY 3 DESC
-- Проверка
SELECT COUNT([View].View_ID) AS Число_просмотров
FROM 
Video INNER JOIN [View] ON Video.Video_ID=[View].Video_ID
WHERE Video.Category_ID=3
GROUP BY Video.Video_ID, Video.Video_name
ORDER BY COUNT([View].View_ID) DESC; 

