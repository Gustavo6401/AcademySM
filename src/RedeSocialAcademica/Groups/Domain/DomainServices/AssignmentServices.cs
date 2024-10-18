using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.DomainServices
{
    public class AssignmentServices : IAssignmentServices
    {
        public bool DueDateLargerThanToday(DateTime dueDate)
        {
            if (dueDate <= DateTime.Now)
                throw new ArgumentException("Data de Expiração Inválida!");

            return true;
        }

        public bool ValidateAssignmentOnCreate(Assignment assignment)
        {
            DueDateLargerThanToday(assignment.DueDate);
            ValidateName(assignment.Title!);

            return true;
        }

        public bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome Inválido!");

            return true;
        }
    }
}
