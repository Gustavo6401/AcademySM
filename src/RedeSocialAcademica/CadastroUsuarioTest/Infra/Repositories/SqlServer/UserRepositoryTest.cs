using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.ControllerModels;
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
    public class UserRepositoryTest
    {        
        private readonly UserRepository repository;
        public UserRepositoryTest()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AcademySMCadastroUsuario;Trusted_Connection=True;";

            UserDbContext context = new UserDbContext(new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            repository = new UserRepository(context);
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

            await repository.CreateAsync(user);

            ApplicationUser response = await repository.GetByEmail(user.EMail!);

            Assert.AreEqual(user.FullName, response.FullName);
            Assert.AreEqual(user.EMail, response.EMail);
            Assert.AreEqual(user.BirthDate, response.BirthDate);
            Assert.AreEqual(user.Phone, response.Phone);
            Assert.AreEqual(user.EducationalDegree, response.EducationalDegree);
            Assert.AreEqual(user.ActualCourse, response.ActualCourse);
            Assert.AreEqual(user.Curriculum, response.Curriculum);
            Assert.AreEqual(user.Institution, response.Institution);
            Assert.AreEqual(user.PasswordErrors, response.PasswordErrors);
        }

        [TestMethod]
        public async Task GetTest()
        {
            Guid id = Guid.Parse("DC2C850A-0B87-43FE-D630-08DC97E7498D");

            ApplicationUser user = await repository.GetAsync(id);

            Assert.AreEqual(id, user.Id);
            Assert.AreEqual("Amelia Smith", user.FullName);
            Assert.AreEqual("ameliasmith@gmail.com", user.EMail);
            Assert.AreEqual("+TZpwbV-Z&AlOu&&GoBn&yBekcwPRQCb?", user.Password);
            Assert.AreEqual("+44 7384 439840", user.Phone);
            Assert.AreEqual(new DateTime(1991, 3, 15), user.BirthDate);
            Assert.AreEqual("Mestrado", user.EducationalDegree);
            Assert.AreEqual("Direito", user.ActualCourse);
            Assert.AreEqual("Advogada Criminal Britânica que decidiu viver no Brasil.", user.Curriculum);
            Assert.AreEqual("Pontifícia Univerdsidade Católica", user.Institution);
        }

        [TestMethod]
        public async Task GetByEmailTest()
        {
            ApplicationUser user = await repository.GetByEmail("ameliasmith@gmail.com");

            Assert.AreEqual(Guid.Parse("DC2C850A-0B87-43FE-D630-08DC97E7498D"), user.Id);
            Assert.AreEqual("Amelia Smith", user.FullName);
            Assert.AreEqual("ameliasmith@gmail.com", user.EMail);
            Assert.AreEqual("+TZpwbV-Z&AlOu&&GoBn&yBekcwPRQCb?", user.Password);
            Assert.AreEqual("+44 7384 439840", user.Phone);
            Assert.AreEqual(new DateTime(1991, 3, 15), user.BirthDate);
            Assert.AreEqual("Mestrado", user.EducationalDegree);
            Assert.AreEqual("Direito", user.ActualCourse);
            Assert.AreEqual("Advogada Criminal Britânica que decidiu viver no Brasil.", user.Curriculum);
            Assert.AreEqual("Pontifícia Univerdsidade Católica", user.Institution);
        }

        [TestMethod]
        public async Task LoginTest()
        {
            LoginInformations login = await repository.Login("ameliasmith@gmail.com", "+TZpwbV-Z&AlOu&&GoBn&yBekcwPRQCb?");

            Assert.AreEqual(Guid.Parse("DC2C850A-0B87-43FE-D630-08DC97E7498D"), login.Id);
            Assert.AreEqual("Amelia Smith", login.FullName);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.Parse("DC2C850A-0B87-43FE-D630-08DC97E7498D"),
                FullName = "Amelia Smith",
                EMail = "ameliasmith@gmail.com",
                Password = "+TZpwbV-Z&AlOu&&GoBn&yBekcwPRQCb?",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+44 7384 439840",
                EducationalDegree = "Mestrado",
                ActualCourse = "Direito",
                Curriculum = "Advogada Criminal Britânica que decidiu viver no Brasil, resolvi diversos casos complicados dentro da área criminal.",
                Institution = "Pontifícia Univerdsidade Católica",
                PasswordErrors = 0
            };

            await repository.UpdateAsync(user);

            ApplicationUser _return = await repository.GetByEmail(user.EMail!);

            Assert.AreEqual(user.Curriculum, _return.Curriculum);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            Guid id = Guid.Parse("DC2C850A-0B87-43FE-D630-08DC97E7498D");

            await repository.DeleteAsync(id);

            ApplicationUser user = await repository.GetAsync(id);

            Assert.IsNull(user);
        }
    }
}
