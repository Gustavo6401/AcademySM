using Groups.Domain.Models.ViewModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IGroupCategoryApplicationServices
    {
        Task Create(GroupsCategoryViewModel model);
    }
}
