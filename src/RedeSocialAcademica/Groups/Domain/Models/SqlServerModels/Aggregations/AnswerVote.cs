namespace Groups.Domain.Models.SqlServerModels.Aggregations
{
    public class AnswerVote
    {
        public int Id { get; set; }
        public string? Vote { get; set; } // Up or Down
        public DateTime DateVote { get; set; }

        public Answer? Answer { get; set; }
        public int AnswerId { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }
    }
}
