using CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Tokens;
using CadastroUsuario.Domain.Models.MongoDBCollections.TokenPersistence;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CadastroUsuario.Infra.Repositories.MongoDb.TokensDataPersistence
{
    public class TokensRepository : ITokenRepository
    {
        private readonly IMongoCollection<TokensDataDocument> _tokensCollection;
        public TokensRepository(IOptions<TokenSettings> options)
        {
            IMongoClient mongoClient = new MongoClient(options.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _tokensCollection = mongoDatabase.GetCollection<TokensDataDocument>(options.Value.CollectionName);
        }

        public async Task Create(TokenData token)
        {
            TokensDataDocument tokenData = new TokensDataDocument
            {
                Token = token.Token,
                DataCriacaoToken = token.DataCriacaoToken,
                UsuarioId = token.UsuarioId
            };

            await _tokensCollection.InsertOneAsync(tokenData);
        }

        public async Task<TokenData> GetByToken(string token)
        {
            TokensDataDocument tokenData = await _tokensCollection.Find(t => t.Token == token)
                                                                  .SortByDescending(t => t.DataCriacaoToken)
                                                                  .FirstOrDefaultAsync();

            return new TokenData
            {
                Id = Convert.ToString(tokenData.Id),
                Token = tokenData.Token,
                DataCriacaoToken = tokenData.DataCriacaoToken,
                UsuarioId = tokenData.UsuarioId
            };
        }

        public async Task<TokenData> GetTokenByUserId(string userId)
        {
            TokensDataDocument tokenData = await _tokensCollection.Find(t => t.UsuarioId == userId)
                                                                  .SortByDescending(t => t.DataCriacaoToken)
                                                                  .FirstOrDefaultAsync();

            return new TokenData
            {
                Id = Convert.ToString(tokenData.Id),
                Token = tokenData.Token,
                DataCriacaoToken = tokenData.DataCriacaoToken,
                UsuarioId = tokenData.UsuarioId
            };
        }

        public async Task Remove(string id)
        {
            ObjectId idToken = ObjectId.Parse(id);

            await _tokensCollection.FindOneAndDeleteAsync(t => t.Id == idToken);
        }
    }
}
