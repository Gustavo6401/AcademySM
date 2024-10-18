namespace Groups.Domain.Models.SqlServerModels
{
    public class PostVote
    {
        public int Id { get; set; }
        public string? Vote { get; set; }
        public DateTime VoteDate { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }

        public Post? Post { get; set; }
        public int PostId { get; set; }
    }
}
