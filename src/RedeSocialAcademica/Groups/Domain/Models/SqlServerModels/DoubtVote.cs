namespace Groups.Domain.Models.SqlServerModels
{
    public class DoubtVote
    {
        public int Id { get; set; }
        public string? Vote { get; set; } // Up or Down.
        public DateTime DateVote { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }

        public Doubt? Doubt { get; set; }
        public int DoubtId { get; set; }
    }
}
