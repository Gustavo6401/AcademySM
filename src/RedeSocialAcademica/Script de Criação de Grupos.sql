/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Level]
      ,[Tutor]
      ,[Description]
      ,[IsPublic]
  FROM [AcademySMGroups].[dbo].[Courses]