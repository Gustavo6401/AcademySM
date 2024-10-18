using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IConversationUserApplicationServices
    {
        Task Create(ConversationsUsers users);
        Task Delete(int id);
        Task<ConversationsUsers> Get(int id);
        Task<List<ConversationsUsers>> GetUsersByConversationId(int conversationId);
        Task<List<ConversationsUsers>> Index(int conversationId);
        Task Update(ConversationsUsers users);
    }
}
