using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.DomainServices
{
    public class MessageServices : IMessageServices
    {
        public bool ValidateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Escreva o Texto de Sua Mensagem!");

            return true;
        }

        public bool ValidateOnCreate(Message message)
        {
            ValidateContent(message.Content!);

            return true;
        }
    }
}
