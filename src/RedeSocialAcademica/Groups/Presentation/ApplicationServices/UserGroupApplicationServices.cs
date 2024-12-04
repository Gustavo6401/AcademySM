using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.API;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Domain.Models.ViewModels;

namespace Groups.Presentation.ApplicationServices
{
    public class UserGroupApplicationServices : IUserGroupApplicationServices
    {
        private readonly IUserGroupServices _services;
        private readonly IGroupRepository _groupRepository;
        private readonly IUserGroupRepository _repository;
        public UserGroupApplicationServices(IUserGroupServices services, IUserGroupRepository repository,
            IGroupRepository groupRepository)
        {
            _services = services;
            _repository = repository;
            _groupRepository = groupRepository;
        }
        public async Task Create(GroupsUsersViewModel users)
        {
            int id = await _groupRepository.GetIdByPublicId(users.PublicGroupId);

            GroupsUsers groupsUsers = new GroupsUsers
            {
                GroupId = id,
                Role = users.Role,
                UserId = users.UserId
            };

            _services.ValidateUserOnCreate(groupsUsers);

            await _repository.Create(groupsUsers);
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

        public async Task<List<ParticipantGroup>> GetParticipantGroups(Guid userId)
        {
            List<ParticipantGroup>? list = await _repository.GetParticipantGroups(userId);

            return list!;
        }

        public async Task Update(GroupsUsers users)
        {
            _services.ValidateUserOnCreate(users);

            await _repository.Update(users);
        }
    }
}
