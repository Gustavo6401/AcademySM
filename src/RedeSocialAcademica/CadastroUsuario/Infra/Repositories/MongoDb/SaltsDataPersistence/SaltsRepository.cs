using CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Salts;
using CadastroUsuario.Domain.Models.MongoDBCollections.BCryptPersistence;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CadastroUsuario.Infra.Repositories.MongoDb.SaltsDataPersistence
{
    public class SaltsRepository : ISaltsRepository
    {
        private readonly IMongoCollection<SaltsDataDocument> _saltsCollection;
        public SaltsRepository(IOptions<SaltsSettings> saltsSettings)
        {
            IMongoClient mongoClient = new MongoClient(saltsSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(saltsSettings.Value.DatabaseName);

            _saltsCollection = mongoDatabase.GetCollection<SaltsDataDocument>(saltsSettings.Value.SaltsCollectionName);
        }
        public async Task Create(SaltsData saltsData)
        {
            SaltsDataDocument document = new SaltsDataDocument
            {                
                Salt = saltsData.Salt,
                Email = saltsData.Email
            };

            await _saltsCollection.InsertOneAsync(document);
        }            

        public async Task<SaltsData> GetSaltByEmail(string? email)
        {
            SaltsDataDocument document = await _saltsCollection.Find(x => x.Email == email)
                                                 .FirstOrDefaultAsync();

            return new SaltsData
            {
                Id = document.Id.ToString(),
                Salt = document.Salt,
                Email = document.Email
            };
        }
    }
}
