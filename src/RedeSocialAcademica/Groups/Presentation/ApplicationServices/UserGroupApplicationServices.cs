using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Presentation.ApplicationServices
{
    public class UserGroupApplicationServices : IUserGroupApplicationServices
    {
        private readonly IUserGroupServices _services;
        private readonly IUserGroupRepository _repository;
        public UserGroupApplicationServices(IUserGroupServices services, IUserGroupRepository repository)
        {
            _services = services;
            _repository = repository;
        }
        public async Task Create(GroupsUsers users)
        {
            _services.ValidateUserOnCreate(users);

            await _repository.Create(users);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<GroupsUsers> Get(int id)
        {
            GroupsUsers users = await _repository.Get(id);

            return users;
        }

        public async Task<List<GroupsUsers>> GetByGroupId(int groupId)
        {
            List<GroupsUsers> list = await _repository.GetByGroupId(groupId);

            return list;
        }

        public async Task<List<GroupsUsers>> GetByUserId(Guid userId)
        {
            List<GroupsUsers> list = await _repository.GetByUserId(userId);

            return list;
        }

        public async Task Update(GroupsUsers users)
        {
            _services.ValidateUserOnCreate(users);

            await _repository.Update(users);
        }
    }
}
