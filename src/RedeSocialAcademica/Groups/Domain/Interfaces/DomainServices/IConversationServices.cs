using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.DomainServices
{
    public interface IConversationServices
    {
        bool ValidateTitle(string title);
        bool ValidateOnCreate(Conversation conversation);
    }
}
