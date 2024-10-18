using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.DomainServices
{
    public class UserGroupServices : IUserGroupServices
    {
        public bool ValidateUserOnCreate(GroupsUsers groupsUsers)
        {
            ValidateUserRole(groupsUsers.Role!);

            return true;
        }

        public bool ValidateUserRole(string role)
        {
            List<string> roles = new List<string>
            {
                "Aluno",
                "Professor",
                "Instituição"
            };

            if (!roles.Contains(role))
                throw new ArgumentException("Invalid User Role");

            return true;
        }
    }
}
