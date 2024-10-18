using Groups.Domain.Interfaces.Controllers;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
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
    public class GroupCategoryControllerTest
    {
        private readonly IGroupCategoryRepository _repository;
        private readonly IGroupCategoryController _controller;
        public GroupCategoryControllerTest()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AcademySMGroups;Trusted_Connection=True;";

            GroupsDbContext context = new GroupsDbContext(new DbContextOptionsBuilder<GroupsDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            _repository = new GroupCategoryRepository(context);

            _controller = new GroupsCategoryController(_repository);
        }

        [TestMethod]
        public async Task CreateTest()
        {
            CategoryGroups categoryGroups = new CategoryGroups
            {
                CategoryId = 104, // Category - Xadrez
                GroupId = 5 // Group - Do 0 aos 1000 de rating.
            };

            var resp = await _controller.Create(categoryGroups);
            var okResult = resp.Result! as OkObjectResult;

            string? response = okResult!.Value as string;

            Assert.AreEqual("Categoria adicionada ao Grupo com Sucesso!", response);
        }
    }
}
