Use AcademySMCadastroUsuario

-- Brings all of Registers.
Select [ApplicationUser].[FullName],
		[ApplicationUser].[Curriculum],
		[EducationalBackground].[Course],
		[Links].[Origin],
		[Links].[Link],
		ProfilePics.FileNameAndPath
From ApplicationUser
Join ProfilePics On ProfilePics.UserId = ApplicationUser.Id
Join EducationalBackground On EducationalBackground.UserId = ApplicationUser.Id
Join Links On Links.UserId = ApplicationUser.Id
Where ApplicationUser.Id = '3FA85F64-5717-4562-B3FC-2C963F66AFA6'



-- My Web App  Way
Select Top 1
	ApplicationUser.FullName,
	ApplicationUser.Curriculum,
	ProfilePics.FileNameAndPath
From ApplicationUser
Join ProfilePics On ProfilePics.UserId = ApplicationUser.Id
Where ApplicationUser.Id = '3FA85F64-5717-4562-B3FC-2C963F66AFA6'
And ProfilePics.IsActive = 1

Select EducationalBackground.Course
From EducationalBackground
Where UserId = '3FA85F64-5717-4562-B3FC-2C963F66AFA6'

Select Links.Origin,
	Links.Link
From Links
Where UserId = '3FA85F64-5717-4562-B3FC-2C963F66AFA6'