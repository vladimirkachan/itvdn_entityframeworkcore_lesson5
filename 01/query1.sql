USE Lesson8_01
GO 
SELECT com.Name CompanyName, p.[Name] PhoneName, p.Price FROM dbo.Companies com
	JOIN dbo.Phones p
	ON p.CompanyId = com.Id
	ORDER BY p.Price DESC