using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.DomainServices;

public interface IAssignmentServices
{
    bool ValidateName(string name);
    bool DueDateLargerThanToday(DateTime dueDate);
    bool ValidateAssignmentOnCreate(Assignment assignment);
}
