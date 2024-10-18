using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Controllers;
using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Services;
using CadastroUsuario.Infra.Context;
using CadastroUsuario.Infra.Repositories.SqlServer;
using CadastroUsuario.Presentation.ApplicationServices;
using CadastroUsuario.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioTest.Presentation.Controllers
{
    [TestClass]
    public class EducationalBackgroundControllerTest
    {
        private readonly IEducationalBackgroundServices _services;
        private readonly IEducationalBackgroundRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IEducationalBackgroundApplicationServices _applicationServices;
        private readonly IEducationalBackgroundController _controller;
        public EducationalBackgroundControllerTest()
        {
            _services = new EducationalBackgroundServices();

            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AcademySMCadastroUsuario;Trusted_Connection=True;";

            UserDbContext context = new UserDbContext(new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            _userRepository = new UserRepository(context);
            _repository = new EducationalBackgroundRepository(context);

            _applicationServices = new EducationalBackgroundApplicationServices(_repository, _services);

            _controller = new EducationalBackgroundController(_applicationServices);
        }

        [TestMethod]
        public async Task CreateTest()
        {
            EducationalBackground background = new EducationalBackground
            {
                Course = "Direito Criminal",
                EducationalDegree = "Mestrado",
                Status = "Concluído",
                Institution = "Pontifícia Universidade Católica",
                CourseBegin = new DateTime(2021, 02, 05),
                CourseEnd = new DateTime(2023, 11, 27),
                UserId = Guid.Parse("E0B6DA96-92A5-4B52-F7F0-08DCAB831A2B")
            };

            var response = await _controller.Create(background);
            var okResult = response.Result as OkObjectResult;

            string resposta = okResult.Value! as string;

            Assert.AreEqual(resposta, "Formação Cadastrada com Sucesso!");
        }
    }
}
