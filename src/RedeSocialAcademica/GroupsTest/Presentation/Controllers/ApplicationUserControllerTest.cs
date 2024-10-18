using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer;
using Groups.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupsTest.Presentation.Controllers
{
    [TestClass]
    public class ApplicationUserControllerTest
    {
        private readonly IApplicationUserRepository _repository;
        private readonly IApplicationUserController _controller;
        public ApplicationUserControllerTest()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AcademySMGroups;Trusted_Connection=True;";

            GroupsDbContext context = new GroupsDbContext(new DbContextOptionsBuilder<GroupsDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            _repository = new ApplicationUserRepository(context);

            _controller = new ApplicationUserController(_repository);
        }

        [TestMethod]
        public async Task Create()
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = Guid.Parse("E0B6DA96-92A5-4B52-F7F0-08DCAB831A2B"),
                Name = "Amelia Smith",
                EducationalBackground = "Mestrado",
                Institution = "Pontifícia Univerdsidade Católica",
                CourseName = "Direito",
                ProfilePicFilePath = ""
            };

            var resp = await _controller.Create(user);
            var okResult = resp.Result as OkObjectResult;

            string response = okResult.Value! as string;

            Assert.AreEqual("Usuário Cadastrado com Sucesso!", response);
        }
    }
}
