using MongoDB.Bson;

namespace Groups.Infra.Repository.MongoDB.RoomsDataPersistence
{
    public class RoomsDataDocument
    {
        public ObjectId Id { get; set; }
        public string? GroupId { get; set; }
        public string? RoomId { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
