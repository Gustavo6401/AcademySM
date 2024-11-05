using CadastroUsuario.Domain.Interfaces.ApplicationServices;
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
using CadastroUsuario.Infra.Authentication;
using CadastroUsuario.Infra.Context;
using CadastroUsuario.Infra.Cookies;
using CadastroUsuario.Infra.Repositories.MongoDb.SaltsDataPersistence;
using CadastroUsuario.Infra.Repositories.MongoDb.TokensDataPersistence;
using CadastroUsuario.Infra.Repositories.SqlServer;
using CadastroUsuario.Presentation.ApplicationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioTest.Presentation.ApplicationServices
{
    [TestClass]
    public class UserApplicationServicesTest
    {
        private readonly IUserServices _services;
        private readonly IUserRepository _repository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserLockoutRepository _lockoutRepository;
        private readonly IUserLockoutServices _lockoutServices;
        private readonly ICookieConfiguration _cookieConfiguration;
        private readonly GroupsUsersAPI _groupsUsersAPI;
        private readonly IUserApplicationServices _applicationServices;
        private readonly ISaltsRepository _saltsRepository;
        private readonly CookieAuthServices _cookieAuthServices;
        public UserApplicationServicesTest()
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

            _cookieAuthServices = new CookieAuthServices(httpContextAcessor);

            _applicationServices = new UserApplicationServices(_services, _repository, _tokenRepository,
                _lockoutRepository, _lockoutServices, _cookieConfiguration, _groupsUsersAPI, _saltsRepository,
                _cookieAuthServices);
        }

        [TestMethod]
        public async Task Create()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "marcellomuller39@gmail.com",
                Password = "brXE-m3Q5puU5ulj@JRSY6pjO38y-BtZ?",
                BirthDate = new DateTime(1999, 09, 20),
                Phone = "+4915510686794",
                EducationalDegree = "Ensino Médio Técnico",
                ActualCourse = "Informática",
                Curriculum = "Estou iniciando com Técnico de Informática após ter voltado da Alemanha. Sou um desenvolvedor C# e JavaScript",
                Institution = "ETEC",
                PasswordErrors = 0
            };

            await _applicationServices.CreateAsync(user);

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
        public async Task LoginTest()
        {
            Login login = new Login
            {
                Email = "takumisato@email.com",
                Password = "ezep8&CuIvsSTiMt4jR=9TZHlo1rg8P2x"
            };

            LoginReturn resposta = await _applicationServices.Login(login);

            Assert.AreEqual("Usuário Logado com Sucesso!", resposta.ReturnMessage);
        }
    }
}
