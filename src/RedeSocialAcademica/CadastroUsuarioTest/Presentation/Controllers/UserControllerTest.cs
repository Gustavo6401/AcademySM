using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Controllers;
using CadastroUsuario.Domain.Interfaces.Cookies;
using CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Salts;
using CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Tokens;
using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.ControllerModels;
using CadastroUsuario.Domain.Models.MongoDBCollections.BCryptPersistence;
using CadastroUsuario.Domain.Models.MongoDBCollections.TokenPersistence;
using CadastroUsuario.Domain.Services;
using CadastroUsuario.Infra.API.Groups;
using CadastroUsuario.Infra.Context;
using CadastroUsuario.Infra.Cookies;
using CadastroUsuario.Infra.Repositories.MongoDb.SaltsDataPersistence;
using CadastroUsuario.Infra.Repositories.MongoDb.TokensDataPersistence;
using CadastroUsuario.Infra.Repositories.SqlServer;
using CadastroUsuario.Presentation.ApplicationServices;
using CadastroUsuario.Presentation.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioTest.Presentation.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private readonly IUserServices _services;
        private readonly IUserRepository _repository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserLockoutRepository _lockoutRepository;
        private readonly IUserLockoutServices _lockoutServices;
        private readonly ICookieConfiguration _cookieConfiguration;
        private readonly GroupsUsersAPI _groupsUsersAPI;
        private readonly IUserApplicationServices _applicationServices;
        private readonly IUserController _controller;
        private readonly ISaltsRepository _saltsRepository;
        public UserControllerTest()
        {
            _services = new UserServices();

            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AcademySMCadastroUsuario;Trusted_Connection=True;";

            UserDbContext context = new UserDbContext(new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            _repository = new UserRepository(context);

            TokenSettings settings = new TokenSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "TokensDB";
            settings.CollectionName = "Tokens";

            SaltsSettings saltsSettings = new SaltsSettings();
            saltsSettings.ConnectionString = "mongodb://localhost:27017";
            saltsSettings.DatabaseName = "SaltsDB";
            saltsSettings.SaltsCollectionName = "Salts";

            BsonClassMap.RegisterClassMap<TokenData>(tokens =>
            {
                tokens.AutoMap();
                tokens.MapIdProperty(s => s.Id)
                    .SetIdGenerator(ObjectIdGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<SaltsData>(salts =>
            {
                salts.AutoMap();
                salts.MapIdProperty(s => s.Id)
                    .SetIdGenerator(ObjectIdGenerator.Instance);
            });

            IOptions<TokenSettings> options = Options.Create(settings);
            IOptions<SaltsSettings> saltsOptions = Options.Create(saltsSettings);

            _tokenRepository = new TokensRepository(options);
            _saltsRepository = new SaltsRepository(saltsOptions);
            _lockoutRepository = new UserLockoutRepository(context);
            _lockoutServices = new UserLockoutServices();

            IHttpContextAccessor httpContextAcessor = new HttpContextAccessor();

            var httpContext = new DefaultHttpContext();
            httpContextAcessor.HttpContext = httpContext;

            _cookieConfiguration = new CookieConfiguration(httpContextAcessor);

            HttpClient client = new HttpClient();
            _groupsUsersAPI = new GroupsUsersAPI(client);

            _applicationServices = new UserApplicationServices(_services, _repository, _tokenRepository,
                _lockoutRepository, _lockoutServices, _cookieConfiguration, _groupsUsersAPI, _saltsRepository);

            _controller = new UserController(_applicationServices);
        }

        [TestMethod]
        public async Task CreateTest()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Bernardo Rossi",
                EMail = "bernardorossi@gmail.com",
                Password = "brXE-m3Q5puU5ulj@JRSY6pjO38y-BtZ?",
                BirthDate = new DateTime(1999, 09, 20),
                Phone = "+4915510686794",
                EducationalDegree = "Ensino Médio Técnico",
                ActualCourse = "Informática",
                Curriculum = "Estou iniciando com Técnico de Informática após ter voltado da Itália. Sou um desenvolvedor C# e JavaScript",
                Institution = "ETEC",
                PasswordErrors = 0
            };

            await _controller.Create(user);

            ApplicationUser response = await _repository.GetByEmail(user.EMail!);

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
            Guid id = Guid.Parse("315E8374-6618-4B38-F5C7-08DCB2891D95");

            ApplicationUser user = await _applicationServices.GetById(id);

            Assert.AreEqual("Bernardo Rossi", user.FullName);
            Assert.AreEqual("bernardorossi@gmail.com", user.EMail);
            Assert.AreEqual(new DateTime(1999, 09, 20), user.BirthDate);
            Assert.AreEqual("+4915510686794", user.Phone);
            Assert.AreEqual("Ensino Médio Técnico", user.EducationalDegree);
            Assert.AreEqual("Informática", user.ActualCourse);
            Assert.AreEqual("Estou iniciando com Técnico de Informática após ter voltado da Itália. Sou um desenvolvedor C# e JavaScript", user.Curriculum);
            Assert.AreEqual("ETEC", user.Institution);
        }

        [TestMethod]
        public async Task LoginTest()
        {
            Login login = new Login
            {
                Email = "bernardorossi@gmail.com",
                Password = "brXE-m3Q5puU5ulj@JRSY6pjO38y-BtZ?"
            };

            var resp = await _controller.Login(login);
            var okResult = resp.Result as OkObjectResult;

            LoginReturn? response = okResult!.Value! as LoginReturn;

            Assert.AreEqual("Usuário Logado com Sucesso!", response!.ReturnMessage);
        }

        [TestMethod]
        public async Task GetByEmail()
        {
            string email = "bernardorossi@gmail.com";

            ApplicationUser user = await _applicationServices.GetByEmail(email);

            Assert.AreEqual("Bernardo Rossi", user.FullName);
            Assert.AreEqual("bernardorossi@gmail.com", user.EMail);
            Assert.AreEqual(new DateTime(1999, 09, 20), user.BirthDate);
            Assert.AreEqual("+4915510686794", user.Phone);
            Assert.AreEqual("Ensino Médio Técnico", user.EducationalDegree);
            Assert.AreEqual("Informática", user.ActualCourse);
            Assert.AreEqual("Estou iniciando com Técnico de Informática após ter voltado da Itália. Sou um desenvolvedor C# e JavaScript", user.Curriculum);
            Assert.AreEqual("ETEC", user.Institution);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.Parse("315E8374-6618-4B38-F5C7-08DCB2891D95"),
                FullName = "Bernardo Rossi",
                EMail = "bernardorossi@gmail.com",
                Password = "brXE-m3Q5puU5ulj@JRSY6pjO38y-BtZ?",
                BirthDate = new DateTime(1999, 09, 20),
                Phone = "+4915510686794",
                EducationalDegree = "Ensino Médio Técnico",
                ActualCourse = "Informática",
                Curriculum = "Estou iniciando com Técnico de Informática após ter voltado da Itália. Sou um desenvolvedor C# e JavaScript e estou em busca de uma nova oportunidade.",
                Institution = "ETEC",
                PasswordErrors = 0
            };

            await _controller.Update(user);

            var resp = await _controller.GetByEmail(user.EMail);
            var okResult = resp.Result as OkObjectResult;

            ApplicationUser? response = okResult!.Value! as ApplicationUser;

            Assert.AreEqual(user.FullName, response!.FullName);
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
        public async Task Delete()
        {
            Guid id = Guid.Parse("315E8374-6618-4B38-F5C7-08DCB2891D95");

            await _controller.Delete(id);

            ApplicationUser resp = await _applicationServices.GetByEmail("bernardorossi@gmail.com");

            Assert.IsNull(resp);
        }

        [TestMethod]
        public async Task UserDetailsTest()
        {
            Guid id = Guid.Parse("E66BE998-280B-4F0B-F114-08DCBD6F22B2");

            var resp = await _controller.UserDetails(id);
            var okResult = resp.Result as OkObjectResult;

            UserDetailsReturn? userDetails = okResult!.Value! as UserDetailsReturn;

            Assert.AreEqual("Gustavo da Silva Oliveira", userDetails!.FullName);
        }
    }
}
