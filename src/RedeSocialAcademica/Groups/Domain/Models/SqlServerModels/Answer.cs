namespace Groups.Domain.Models.SqlServerModels
{
    public class Answer
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime DateCreation { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }

        public Doubt? Doubt { get; set; }
        public int DoubtId { get; set; }
    }
}
