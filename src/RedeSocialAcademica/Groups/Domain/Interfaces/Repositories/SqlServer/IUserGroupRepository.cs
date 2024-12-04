using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.API;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IUserGroupRepository : ISqlServerRepositoryBase<GroupsUsers>
    {
        Task<List<GroupsUsers>> GetByUserId(Guid userId);
        Task<List<GroupsUsers>> GetByGroupId(int groupId);        
        Task<GroupsUsers> GetByUserAndGroupId(Guid userId, int groupId);
        Task<List<ParticipantGroup>> GetParticipantGroups(Guid userId);
    }
}
