using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface IAnswerCommentServices
    {
        bool ValidateComment(string comment);
        bool ValidateOnCreate(AnswerComment comment);
    }
}
