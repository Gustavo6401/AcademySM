Use AcademySMGroups

Select [Courses].[Id],
	   [Courses].[Name],
	   [GroupsUsers].[Role],
	   CategoryIcons.[Icon]
From GroupsUsers
Join Courses On [GroupsUsers].GroupId = [Courses].Id
Outer Apply ( -- Generated Script with ChatGPT
	Select Top 1 Categories.Icon
	From CategoryGroups
	Join Categories On CategoryGroups.CategoryId = Categories.Id
	Where CategoryGroups.GroupId = Courses.Id
	ORDER BY Categories.Id
) As CategoryIcons
Where GroupsUsers.UserId = '3FA85F64-5717-4562-B3FC-2C963F66AFA6'