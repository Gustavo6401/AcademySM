namespace Groups.Domain.Models.SqlServerModels
{
    public class Article
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Writer { get; set; }
        public string? FilePath { get; set; }
        public int YearWriting { get; set; }
        public DateTime DateCreation { get; set; }

        public Courses? Group { get; set; }
        public int GroupId { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }
    }
}
