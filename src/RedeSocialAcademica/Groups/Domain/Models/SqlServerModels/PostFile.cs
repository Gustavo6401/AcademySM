namespace Groups.Domain.Models.SqlServerModels
{
    public class PostFile
    {
        public int Id { get; set; }
        public string? RelativePath { get; set; }

        public Post? Post { get; set; }
        public int PostId { get; set; }
    }
}
