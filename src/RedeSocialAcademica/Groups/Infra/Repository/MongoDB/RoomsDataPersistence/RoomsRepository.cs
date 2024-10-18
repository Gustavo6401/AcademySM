using Groups.Domain.Models.MongoDBModels.Rooms;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Groups.Infra.Repository.MongoDB.RoomsDataPersistence
{
    public class RoomsRepository
    {
        private readonly IMongoCollection<RoomsDataDocument> _roomsCollection;
        public RoomsRepository(IOptions<RoomSettings> roomSettings)
        {
            IMongoClient client = new MongoClient(roomSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(roomSettings.Value.DatabaseName);

            _roomsCollection = database.GetCollection<RoomsDataDocument>(roomSettings.Value.CollectionName);
        }

        public async Task Create(Room room)
        {
            RoomsDataDocument document = new RoomsDataDocument
            {
                GroupId = room.GroupId,
                RoomId = room.RoomId,
                DateCreation = room.DateCreation
            };

            await _roomsCollection.InsertOneAsync(document);
        }

        public async Task<string> GetRecentRoomId(int groupId)
        {
            RoomsDataDocument document = await _roomsCollection.Find(r => r.GroupId == groupId)
                .SortByDescending(r => r.DateCreation)
                .FirstOrDefaultAsync();

            return document.RoomId!;
        }
    }
}
