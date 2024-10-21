USE [AcademySMGroups]
GO

INSERT INTO [dbo].[Courses]
           ([Name]
           ,[Level]
           ,[Tutor]
           ,[Description]
           ,[IsPublic])
     VALUES
           ('Do 0 ao 1000 de Rating', 'Básico', 'Gustavo da Silva Oliveira', 'Ensinarei você um completo iniciante a conseguir seus primeiros 1000 de rating.', 1),
		   ('TDD em C#', 'Básico', 'Gustavo da Silva Oliveira', 'Aprenda a Testar Suas Aplicações', 1)

Insert Into [dbo].[CategoryGroups]
			([GroupId],
			[CategoryId])
	 Values
			(1, 104),
			(2, 110),
			(3, 3),
			(3, 10),
			(4, 104)
GO


