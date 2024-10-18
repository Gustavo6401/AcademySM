namespace Groups.Domain.Models.SqlServerModels.Aggregations
{
    public class CategoryGroups
    {
        public Category? Category { get; set;  }
        public int CategoryId { get; set; }

        public Courses? Group { get; set; }
        public int GroupId { get; set; }
    }
}
