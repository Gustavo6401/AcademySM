using CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Salts;
using CadastroUsuario.Domain.Models.MongoDBCollections.BCryptPersistence;
using CadastroUsuario.Infra.Repositories.MongoDb.SaltsDataPersistence;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioTest.Infra.Repositories.MongoDb.SaltsDataPersistence
{
    [TestClass]
    public class SaltsRepositoryTest
    {
        private readonly SaltsSettings settings;
        private readonly ISaltsRepository repository;
        public SaltsRepositoryTest()
        {
            settings = new SaltsSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "SaltsDB";
            settings.SaltsCollectionName = "Salts";

            BsonClassMap.RegisterClassMap<SaltsData>(salts =>
            {
                salts.AutoMap();
                salts.MapIdProperty(s => s.Id)
                    .SetIdGenerator(ObjectIdGenerator.Instance);
            });

            IOptions<SaltsSettings> options = Options.Create(settings);

            repository = new SaltsRepository(options);
        }

        [TestMethod]
        [TestCategory("CreateSalt")]
        public async Task CreateTest()
        {
            SaltsData salts = new SaltsData();
            salts.Email = "mullermarcello39@gmail.com";
            salts.Salt = "$2a$18$zmTN22SudHIRVk9Vg0RXTO";

            await repository.Create(salts);

            SaltsData response = await repository.GetSaltByEmail(salts.Email);

            Assert.AreEqual(salts.Email, response.Email);
            Assert.AreEqual(salts.Salt, response.Salt);
        }

        [TestMethod]
        [TestCategory("GetSalt")]
        public async Task GetSaltByEmailTest()
        {
            SaltsData response = await repository.GetSaltByEmail("mullermarcello39@gmail.com");

            Assert.AreEqual("mullermarcello39@gmail.com", response.Email);
            Assert.AreEqual("$2a$18$zmTN22SudHIRVk9Vg0RXTO", response.Salt);
        }
    }
}
