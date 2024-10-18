namespace Groups.Domain.Models.SqlServerModels
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MainCategory { get; set; }
        public string? Icon { get; set; }

        public ICollection<Courses>? Groups { get; set; }
    }
}
