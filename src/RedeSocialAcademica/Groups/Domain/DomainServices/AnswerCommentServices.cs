using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.DomainServices
{
    public class AnswerCommentServices : IAnswerCommentServices
    {
        public bool ValidateComment(string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
                throw new ArgumentException("Texto de Comentário Inválido!");

            return true;
        }

        public bool ValidateOnCreate(AnswerComment comment)
        {
            ValidateComment(comment.Content!);

            return true;
        }
    }
}
