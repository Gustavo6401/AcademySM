using Groups.Domain.Models.MongoDBModels.Faturas;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Groups.Infra.Repository.MongoDB.FaturaDataPersistence
{
    public class FaturaRepository
    {
        private readonly IMongoCollection<FaturaDataDocument> _faturasCollection;
        public FaturaRepository(IOptions<FaturaSettings> faturaSettings)
        {
            IMongoClient client = new MongoClient(faturaSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(faturaSettings.Value.DatabaseName);

            _faturasCollection = database.GetCollection<FaturaDataDocument>(faturaSettings.Value.CollectionName);
        }

        public async Task Create(Fatura fatura)
        {
            FaturaDataDocument document = new FaturaDataDocument
            {
                Valor = fatura.Valor,
                DataGeracao = fatura.DataGeracao,
                UserId = fatura.UserId,
                Status = fatura.Status
            };

            await _faturasCollection.InsertOneAsync(document);
        }

        public async Task<List<Fatura>> GetAllUserFaturas(Guid userId)
        {
            List<FaturaDataDocument> document = await _faturasCollection.Find(f => f.UserId == userId)
                .SortByDescending(f => f.DataGeracao)
                .ToListAsync();

            List<Fatura> faturas = new List<Fatura>();

            foreach (var item in document)
            {
                Fatura fatura = new Fatura
                {
                    Id = item.Id.ToString(),
                    Valor = item.Valor,
                    DataGeracao = item.DataGeracao,
                    UserId = item.UserId,
                    Status = item.Status
                };

                faturas.Add(fatura);
            }

            return faturas;
        }
    }
}
