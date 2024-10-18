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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioTest.Presentation.Controllers
{
    [TestClass]
    public class ProfilePicControllerTest
    {
        private readonly IProfilePicServices _services;
        private readonly IProfilePictureRepository _repository;
        private readonly IProfilePicApplicationServices _applicationServices;
        private readonly IProfilePicController _controller;

        public ProfilePicControllerTest()
        {
            _services = new ProfilePicServices();

            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AcademySMCadastroUsuario;Trusted_Connection=True;";

            UserDbContext context = new UserDbContext(new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            _repository = new ProfilePicRepository(context);

            _applicationServices = new ProfilePicApplicationServices(_repository);

            _controller = new ProfilePicController(_applicationServices);
        }

        [TestMethod]
        public async Task Create()
        {
            ProfilePic profilePic = new ProfilePic()
            {
                FileNameAndPath = "./assets/Amelia_Smith_13-08-2024_23-24",
                DateCreation = DateTime.Now,
                IsActive = true,
                UserId = Guid.Parse("E0B6DA96-92A5-4B52-F7F0-08DCAB831A2B")
            };

            var resp = await _controller.Create(profilePic);
            var okResult = resp.Result as OkObjectResult;

            string response = okResult!.Value as string;

            Assert.AreEqual("Foto de Perfil Cadastrada Com Sucesso!", response);
        }
    }
}
