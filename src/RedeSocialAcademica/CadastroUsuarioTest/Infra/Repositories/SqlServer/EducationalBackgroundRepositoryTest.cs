using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Infra.Context;
using CadastroUsuario.Infra.Repositories.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioTest.Infra.Repositories.SqlServer
{
    [TestClass]
    public class EducationalBackgroundRepositoryTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IEducationalBackgroundRepository _educationBackgroundRepository;
        public EducationalBackgroundRepositoryTest() 
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AcademySMCadastroUsuario;Trusted_Connection=True;";

            UserDbContext context = new UserDbContext(new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            _userRepository = new UserRepository(context);
            _educationBackgroundRepository = new EducationalBackgroundRepository(context);
        }

        [TestMethod]
        public async Task AddTest()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Amelia Smith",
                EMail = "ameliasmith@gmail.com",
                Password = "+TZpwbV-Z&AlOu&&GoBn&yBekcwPRQCb?",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+44 7384 439840",
                EducationalDegree = "Mestrado",
                ActualCourse = "Direito",
                Curriculum = "Advogada Criminal Britânica que decidiu viver no Brasil.",
                Institution = "Pontifícia Univerdsidade Católica",
                PasswordErrors = 0
            };

            await _userRepository.CreateAsync(user);

            ApplicationUser resp = await _userRepository.GetByEmail(user.EMail);

            EducationalBackground background = new EducationalBackground
            {
                Course = "Direito Criminal",
                EducationalDegree = "Mestrado",
                Status = "Concluído",
                Institution = "Pontifícia Universidade Católica",
                CourseBegin = new DateTime(2021, 02, 05),
                CourseEnd = new DateTime(2023, 11, 27),
                UserId = resp.Id
            };

            await _educationBackgroundRepository.CreateAsync(background);

            List<EducationalBackground> list = await _educationBackgroundRepository.GetByUserId(resp.Id);

            Assert.AreEqual(background.Course, list.ElementAt(0).Course);
            Assert.AreEqual(background.EducationalDegree, list.ElementAt(0).EducationalDegree);
            Assert.AreEqual(background.Status, list.ElementAt(0).Status);
            Assert.AreEqual(background.Institution, list.ElementAt(0).Institution);
            Assert.AreEqual(background.CourseBegin, list.ElementAt(0).CourseBegin);
            Assert.AreEqual(background.CourseEnd, list.ElementAt(0).CourseEnd);
            Assert.AreEqual(background.UserId, list.ElementAt(0).UserId);
        }

        [TestMethod]
        public async Task GetByUserIdTest()
        {
            Guid ameliaId = Guid.Parse("E0B6DA96-92A5-4B52-F7F0-08DCAB831A2B");
            // Amelia's Smith EducationalBackgrounds.
            List<EducationalBackground>? list = await _educationBackgroundRepository.GetByUserId(ameliaId);

            Assert.AreEqual("Direito Criminal", list.ElementAt(0).Course);
            Assert.AreEqual("Mestrado", list.ElementAt(0).EducationalDegree);
            Assert.AreEqual("Concluído", list.ElementAt(0).Status);
            Assert.AreEqual("Pontifícia Universidade Católica", list.ElementAt(0).Institution);
            Assert.AreEqual(new DateTime(2021, 02, 05), list.ElementAt(0).CourseBegin);
            Assert.AreEqual(new DateTime(2023, 11, 27), list.ElementAt(0).CourseEnd);
            Assert.AreEqual(ameliaId, list.ElementAt(0).UserId);
        }
    }
}
