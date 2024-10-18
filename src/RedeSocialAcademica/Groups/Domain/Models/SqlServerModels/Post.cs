namespace Groups.Domain.Models.SqlServerModels
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime DateCreation { get; set; }
        public string? Content { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }

        public Courses? Group { get; set; }
        public int GroupId { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<PostVote>? Votes { get; set; }
        public ICollection<PostFile>? Files { get; set; }
    }
}
