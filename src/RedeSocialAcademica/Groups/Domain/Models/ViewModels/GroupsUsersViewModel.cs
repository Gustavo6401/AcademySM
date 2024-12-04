using Groups.Domain.Models.SqlServerModels;
using System.Text.Json.Serialization;

namespace Groups.Domain.Models.ViewModels
{
    public class GroupsUsersViewModel
    {
        public int Id { get; set; }
        public string? Role { get; set; }

        [JsonIgnore]
        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public Courses? Group { get; set; }
        public Guid PublicGroupId { get; set; }
    }
}
