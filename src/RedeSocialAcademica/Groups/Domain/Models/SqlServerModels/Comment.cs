namespace Groups.Domain.Models.SqlServerModels
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime DateCreation { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }

        public Post? Post { get; set; }
        public int PostId { get; set; }
    }
}
