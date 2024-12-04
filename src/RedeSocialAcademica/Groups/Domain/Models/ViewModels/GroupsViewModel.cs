namespace Groups.Domain.Models.ViewModels
{
    public class GroupsViewModel
    {
        public Guid GroupId { get; set; }
        public string? GroupTitle { get; set; }
        public string? GroupLevel { get; set; }
        public string? GroupCategoryIcon { get; set; }
    }
}
