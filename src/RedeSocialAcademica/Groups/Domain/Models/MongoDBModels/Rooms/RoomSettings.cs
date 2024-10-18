namespace Groups.Domain.Models.MongoDBModels.Rooms
{
    public class RoomSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? CollectionName { get; set; }
    }
}
