SELECT Category.Category_ID, Category.Category_title, AVG(Videofile.Videofile_size) FROM 
Category INNER JOIN (Video INNER JOIN Videofile ON VIdeo.Video_ID=Videofile.Video_ID)
ON Video.Category_ID=Category.Category_ID
GROUP BY Category.Category_ID, Category.Category_title
ORDER BY 3 DESC;

 
