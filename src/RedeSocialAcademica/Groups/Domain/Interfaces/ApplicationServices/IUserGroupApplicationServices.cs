using Groups.Domain.Models.API;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Domain.Models.ViewModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IUserGroupApplicationServices
    {
        Task Create(GroupsUsersViewModel users);
        Task Delete(int id);
        Task<GroupsUsers> Get(int id);
        Task<List<GroupsUsers>> GetByUserId(Guid userId);
        Task<List<GroupsUsers>> GetByGroupId(int groupId);
        Task<List<ParticipantGroup>> GetParticipantGroups(Guid userId);
        Task Update(GroupsUsers users);
    }
}
