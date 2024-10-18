using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface IDoubtServices
    {
        bool ValidateTitle(string title);
        bool ValidateContent(string content);
        bool ValidateQuestionStatus(string status);
        bool ValidateOnCreate(Doubt doubt);
    }
}
