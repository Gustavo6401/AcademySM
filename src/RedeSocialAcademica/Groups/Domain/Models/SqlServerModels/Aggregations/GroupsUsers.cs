using System.Text.Json.Serialization;

namespace Groups.Domain.Models.SqlServerModels.Aggregations
{
    public class GroupsUsers
    {
        public int Id { get; set; }
        public string? Role { get; set; }

        [JsonIgnore]
        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public Courses? Group { get; set; }
        public int GroupId { get; set; }
    }
}
