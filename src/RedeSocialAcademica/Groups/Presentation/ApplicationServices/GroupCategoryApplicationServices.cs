using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Domain.Models.ViewModels;

namespace Groups.Presentation.ApplicationServices
{
    public class GroupCategoryApplicationServices : IGroupCategoryApplicationServices
    {
        private readonly IGroupCategoryRepository _repository;
        private readonly IGroupRepository _groupRepository;
        public GroupCategoryApplicationServices(IGroupCategoryRepository repository, IGroupRepository
            groupRepository)
        {
            _repository = repository;
            _groupRepository = groupRepository;
        }
        public async Task Create(GroupsCategoryViewModel model)
        {
            int groupId = await _groupRepository.GetIdByPublicId(model.PublicGroupId);

            CategoryGroups categoryGroups = new CategoryGroups
            {
                GroupId = groupId,
                CategoryId = model.CategoryId
            };

            await _repository.Create(categoryGroups);
        }
    }
}
