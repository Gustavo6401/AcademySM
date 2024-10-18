using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IConversationUserRepository : ISqlServerRepositoryBase<ConversationsUsers>
    {
        Task<List<ConversationsUsers>> GetUsersByConversationId(int conversationId);
        Task<List<ConversationsUsers>> GetAllAdmins(int conversationId);
        Task<ConversationsUsers> GetByConversationAndUserId(Guid userId, int conversationId);
    }
}
