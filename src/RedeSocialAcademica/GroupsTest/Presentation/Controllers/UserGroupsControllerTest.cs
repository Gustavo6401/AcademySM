using Groups.Domain.DomainServices;
using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer;
using Groups.Presentation.ApplicationServices;
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
    public class UserGroupsControllerTest
    {
        private readonly IUserGroupServices _services;
        private readonly IUserGroupRepository _repository;
        private readonly IUserGroupApplicationServices _applicationServices;
        private readonly IUserGroupController _controller;
        public UserGroupsControllerTest()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AcademySMGroups;Trusted_Connection=True;";

            GroupsDbContext context = new GroupsDbContext(new DbContextOptionsBuilder<GroupsDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            _services = new UserGroupServices();

            _repository = new UserGroupRepository(context);

            _applicationServices = new UserGroupApplicationServices(_services, _repository);

            _controller = new UserGroupController(_applicationServices);
        }

        [TestMethod]
        public async Task CreateTest()
        {
            GroupsUsers groupsUsers = new GroupsUsers
            {
                Role = "Professor",
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"), // Gustavo da Silva Oliveira
                GroupId = 1 // Do 0 aos 1000 de Rating
            };

            var resp = await _controller.Create(groupsUsers);
            var okResult = resp.Result! as OkObjectResult;

            string? response = okResult!.Value as string;

            Assert.AreEqual("Cadastrado no Grupo com Sucesso!", response);
        }
    }
}
