using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Models.ViewModels
{
    public class GroupsHomeViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Level { get; set; }
        public string? Description { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
