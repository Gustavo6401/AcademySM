using Audit.Domain.Interfaces.Repository;
using Audit.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Audit.Infra.Repositories
{
    public class UserActionRepository : IUserActionRepository
    {
        private readonly IMongoCollection<UserActionDocument> _mongoCollection;
        public UserActionRepository(IOptions<UserActionSettings> options)
        {
            IMongoClient mongoClient = new MongoClient(options.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _mongoCollection = mongoDatabase.GetCollection<UserActionDocument>(options.Value.CollectionName);
        }
        public async Task CreateAction(UserAction action)
        {
            UserActionDocument document = new UserActionDocument
            {
                APIName = action.APIName,
                Route = action.Route,
                UserId = action.UserId,
                CreatedAt = action.CreatedAt,
                IPv4 = action.IPv4,
                IPv6 = action.IPv6,
                Action = action.Action,
                Token = action.Token
            };

            await _mongoCollection.InsertOneAsync(document);
        }

        public Task<UserAction> GetAction(string? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserAction>> GetLastFiveActionsMadeByTheSameToken(string token)
        {
            var filter = Builders<UserActionDocument>.Filter.Eq(x => x.Token, token);
            var sort = Builders<UserActionDocument>.Sort.Descending(x => x.CreatedAt); // Substitua 'CreatedAt' pelo campo adequado

            List<UserActionDocument> userActionDocuments = await _mongoCollection.Find(filter)
                                                                                 .Sort(sort)
                                                                                 .Limit(5)
                                                                                 .ToListAsync();

            List<UserAction> lista = new List<UserAction>();

            foreach(var item in userActionDocuments)
            {
                UserAction action = new UserAction
                {
                    Id = item.Id.ToString(),
                    APIName = item.APIName,
                    Route = item.Route,
                    UserId = item.UserId,
                    CreatedAt = item.CreatedAt,
                    IPv4 = item.IPv4,
                    IPv6 = item.IPv6,
                    Action = item.Action,
                    Token = item.Token
                };

                lista.Add(action);
            }

            return lista;
        }
    }
}
