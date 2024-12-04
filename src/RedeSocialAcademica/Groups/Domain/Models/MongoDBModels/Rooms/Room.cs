namespace Groups.Domain.Models.MongoDBModels.Rooms
{
    public class Room
    {
        public string? Id { get; set; }
        public string? GroupId { get; set; }
        public string? RoomId { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
