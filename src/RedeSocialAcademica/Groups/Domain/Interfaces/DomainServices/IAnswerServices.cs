using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface IAnswerServices
    {
        bool ValidateTitle(string title);
        bool ValidateAnswer(string answer);
        bool ValidateOnCreate(Answer answer);
    }
}
