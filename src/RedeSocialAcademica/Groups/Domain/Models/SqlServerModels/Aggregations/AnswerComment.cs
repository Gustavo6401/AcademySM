namespace Groups.Domain.Models.SqlServerModels.Aggregations
{
    public class AnswerComment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime DateCreated { get; set; }

        public Answer? Answer { get; set; }
        public int AnswerId { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }
    }
}
