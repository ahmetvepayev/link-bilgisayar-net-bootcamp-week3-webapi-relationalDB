USE ProductsDb
GO

CREATE PROC sp_GetFullProducts
AS
BEGIN

SELECT c.Name 'CategoryName', p.Name, p.Price, pf.Height, pf.Width FROM Products p
JOIN Categories c ON p.CategoryId=c.Id
JOIN ProductFeatures pf ON pf.Id=p.Id

END