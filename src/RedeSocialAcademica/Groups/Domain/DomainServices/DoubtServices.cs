using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.DomainServices
{
    public class DoubtServices : IDoubtServices
    {
        public bool ValidateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Por favor, explique sua dúvida");

            return true;
        }

        public bool ValidateOnCreate(Doubt doubt)
        {
            ValidateContent(doubt.Content!);
            ValidateTitle(doubt.Title!);
            ValidateQuestionStatus(doubt.Status!);

            return true;
        }

        public bool ValidateQuestionStatus(string status)
        {
            List<string> questionPossibleStatus = new List<string>
            {
                "Não Respondida",
                "Respondida",
                "Fechada"
            };

            if (!questionPossibleStatus.Contains(status))
                throw new ArgumentException("O Status da Resposta deve ser um dos informados acima.");

            return true;
        }

        public bool ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Por favor, coloque um título em sua dúvida!");

            return true;
        }
    }
}
