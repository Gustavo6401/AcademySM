using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IUserGroupApplicationServices
    {
        Task Create(GroupsUsers users);
        Task Delete(int id);
        Task<GroupsUsers> Get(int id);
        Task<List<GroupsUsers>> GetByUserId(Guid userId);
        Task<List<GroupsUsers>> GetByGroupId(int groupId);
        Task Update(GroupsUsers users);
    }
}
