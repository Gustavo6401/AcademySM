namespace Groups.Domain.Models.SqlServerModels.Aggregations
{
    public class AssignmentSent
    {
        public int Id { get; set; }
        public DateTime DateSent { get; set; }
        public string? FilePath { get; set; }
        public float Rate { get; set; }

        public Assignment? Assignment { get; set; }
        public int AssignmentId { get; set; }

        public ApplicationUser? User { get; set; }
        public Guid UserId { get; set; }
    }
}
