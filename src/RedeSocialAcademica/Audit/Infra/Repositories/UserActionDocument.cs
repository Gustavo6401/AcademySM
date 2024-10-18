using MongoDB.Bson;
using System.Runtime.Serialization;

namespace Audit.Infra.Repositories
{
    public class UserActionDocument
    {
        public ObjectId Id { get; set; }
        public string? APIName { get; set; }
        public string? Route { get; set; }
        public string? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? IPv4 { get; set; }
        public string? IPv6 { get; set; }
        public string? Action { get; set; }
        public string? Token { get; set; }
    }
}
