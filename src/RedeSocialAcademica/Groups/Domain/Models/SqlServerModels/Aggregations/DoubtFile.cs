namespace Groups.Domain.Models.SqlServerModels.Aggregations
{
    public class DoubtFile
    {
        public int Id { get; set; }
        public string? FilePath { get; set; }

        public int DoubtId { get; set; }
        public Doubt? Doubt { get; set; }
    }
}
