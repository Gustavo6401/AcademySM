namespace Groups.Domain.Models.SqlServerModels
{
    public class Announcement
    {
        public int Id { get; set; }
        public string? AnnouncementText { get; set; }
        public DateTime DateAnnouncement { get; set; }

        public Courses? Group { get; set; }
        public int GroupId { get; set; }
    }
}
