using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Models.ViewModels
{
    public class GroupsHomeViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Level { get; set; }
        public string? Description { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
