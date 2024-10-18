using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface IUserGroupServices
    {
        bool ValidateUserRole(string role);
        bool ValidateUserOnCreate(GroupsUsers groupsUsers);
    }
}
