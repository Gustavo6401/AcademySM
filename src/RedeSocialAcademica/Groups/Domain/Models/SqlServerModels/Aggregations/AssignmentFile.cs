namespace Groups.Domain.Models.SqlServerModels.Aggregations
{
    public class AssignmentFile
    {
        public int Id { get; set; }
        public string? Path { get; set; }

        public Assignment? Assignment { get; set; }
        public int AssignmentId { get; set; }
    }
}
