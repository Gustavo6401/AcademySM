-- Users must be created in the Web Application.

Insert Into EducationalBackground (Id, Course, EducationalDegree, [Status], Institution, CourseBegin, CourseEnd, UserId)
Values ('265b91c9-4dbe-4fb6-88f2-3af045b7604b', 'Informática', 'Ensino Técnico', 'Concluído', 'Instituto Social Nossa Senhora de Fátima', '2019-01-28', '2019-12-14', '3FA85F64-5717-4562-B3FC-2C963F66AFA6'),
		('a1205650-fca2-410d-9e5d-466ff5fab3e6', 'Análise e Desenvolvimento de Sistemas', 'Ensino Superior', 'Concluído', 'Centro Universitário Senac', '2021-02-15', '2023-06-14', '3FA85F64-5717-4562-B3FC-2C963F66AFA6')

Insert Into Links (Origin, Link, UserId)
Values ('Chess.com', 'https://www.chess.com/member/gustavo6401', '3FA85F64-5717-4562-B3FC-2C963F66AFA6'),
		('YouTube', 'https://www.youtube.com/@escoladeprogramacao10', '3FA85F64-5717-4562-B3FC-2C963F66AFA6')

Insert Into ProfilePics (Id, FileNameAndPath, DateCreation, IsActive, UserId)
Values ('bdd4fba5-7f67-4981-a107-ce6fe4c4a114' ,'2024-10-31 18-44-50Z-foto_gustavo.jpg', '2024-10-31 21:44:16.5840000', 1, '3FA85F64-5717-4562-B3FC-2C963F66AFA6')