Use AcademySMGroups

Select [Courses].[Id],
	   [Courses].[Name],
	   [GroupsUsers].[Role],
	   CategoryIcons.[Icon]
From (((GroupsUsers
Join Courses On [GroupsUsers].GroupId = [Courses].Id)
And (Select [Categories].[Icon]
	[Categories].[Id]
	 From Categories
	 Where) 
Where UserId = '3FA85F64-5717-4562-B3FC-2C963F66AFA6'