using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.DomainServices
{
    public class ConversationServices : IConversationServices
    {
        public bool ValidateOnCreate(Conversation conversation)
        {
            ValidateTitle(conversation.Title!);

            return true;
        }

        public bool ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Título Inválido");

            return true;
        }
    }
}
