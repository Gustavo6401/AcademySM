using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Models.SqlServerModels
{
    public class Doubt
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Status { get; set; }
        public DateTime DateCreation { get; set; }

        public Courses? Group { get; set; }
        public int GroupId { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }

        public ICollection<DoubtVote>? Votes { get; set; }
        public ICollection<Answer>? Answers { get; set; }
        public ICollection<DoubtFile>? Files { get; set; }
    }
}
