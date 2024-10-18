using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.DomainServices
{
    public class AnswerServices : IAnswerServices
    {
        public bool ValidateAnswer(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
                throw new ArgumentException("Resposta Inválida!");

            return true;
        }

        public bool ValidateOnCreate(Answer answer)
        {
            ValidateAnswer(answer.Content!);
            ValidateTitle(answer.Title!);

            return true;
        }

        public bool ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Título da Resposta Inválida");

            return true;
        }
    }
}
