using Groups.Domain.DomainServices;
using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Domain.Models.ViewModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer;
using Groups.Presentation.ApplicationServices;
using Groups.Presentation.Controllers;
using Groups.Presentnation.Controllers;
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
    public class CoursesControllerTest
    {
        private IGroupRepository _repository;
        private IGroupServices _services;
        private IGroupApplicationServices _applicationServices;
        private IGroupController _controller;

        public CoursesControllerTest()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AcademySMGroups;Trusted_Connection=True;";

            GroupsDbContext context = new GroupsDbContext(new DbContextOptionsBuilder<GroupsDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            _services = new GroupServices();

            _repository = new GroupRepository(context);

            _applicationServices = new GroupApplicationServices(_services, _repository);

            _controller = new GroupController(_applicationServices);
        }

        [TestMethod]
        public async Task CreateGroup()
        {
            Courses group = new Courses
            {
                Name = "Meu Método de Estudar idiomas",
                Level = "Básico",
                Tutor = "Gustavo da Silva Oliveira",
                Description = "O objetivo desse curso é ensinar a minha maneira de estudar idiomas, que é uma forma bastante consolidada entre os poliglotas. O que me levou a aprender inglês, alemão e francês",
                IsPublic = true
            };

            var resp = await _controller.Create(group);
            var okResult = resp.Result! as OkObjectResult;

            CreateGroupViewModel? response = okResult!.Value! as CreateGroupViewModel;

            Assert.AreEqual(response!.Message, "Grupo Criado com Sucesso!");
            Assert.AreEqual(response!.GroupId, 9);
        }

        [TestMethod]
        public async Task Groups()
        {
            var resp = await _controller.Groups();
            var okResult = resp.Result! as OkObjectResult;

            List<GroupsViewModel>? response = okResult!.Value! as List<GroupsViewModel>;

            Assert.AreEqual(response![0].GroupId, 1);
            Assert.AreEqual(response![0].GroupTitle, "Do 0 aos 1000 de Rating");
            Assert.AreEqual(response![0].GroupLevel, "Básico");
        }
    }
}
