using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface IGroupServices
    {
        bool ValidateOnCreate(Courses course);
        bool ValidateName(string name);
        bool ValidateLevel(string level);
        bool ValidateTutorName(string tutor);
        bool ValidateDescription(string description);
    }
}
