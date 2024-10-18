using System.Text.Json.Serialization;

namespace Groups.Domain.Models.SqlServerModels
{
    public class Courses
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Level { get; set; }
        public string? Tutor { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; }

        [JsonIgnore]
        public ICollection<Category>? Categories { get; set; }
        [JsonIgnore]
        public ICollection<Assignment>? Assignments { get; set; }
        [JsonIgnore]
        public ICollection<Doubt>? Doubts { get; set; }
        [JsonIgnore]
        public ICollection<ApplicationUser>? Users { get; set; }
        [JsonIgnore]
        public ICollection<Post>? Posts { get; set; }
        [JsonIgnore]
        public ICollection<Article>? Articles { get; set; }
        [JsonIgnore]
        public ICollection<Announcement>? Announcements { get; set; }
    }
}
