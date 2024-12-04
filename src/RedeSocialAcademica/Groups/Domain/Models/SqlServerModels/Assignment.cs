using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Models.SqlServerModels
{
    public class Assignment
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DueDate { get; set; }
        public float NoteValue { get; set; }
        public Guid PublicId { get; set; }

        public Courses? Group { get; set; }
        public int GroupId { get; set; }

        public ICollection<AssignmentSent>? Sents { get; set; }
    }
}
