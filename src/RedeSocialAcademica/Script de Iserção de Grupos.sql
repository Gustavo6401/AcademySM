USE [AcademySMGroups]
GO

INSERT INTO [dbo].[Courses]
           ([Name]
           ,[Level]
           ,[Tutor]
           ,[Description]
           ,[IsPublic])
     VALUES
           ('Do 0 ao 1000 de Rating', 'B�sico', 'Gustavo da Silva Oliveira', 'Ensinarei voc� um completo iniciante a conseguir seus primeiros 1000 de rating.', 1),
		   ('TDD em C#', 'B�sico', 'Gustavo da Silva Oliveira', 'Aprenda a Testar Suas Aplica��es', 1)

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


