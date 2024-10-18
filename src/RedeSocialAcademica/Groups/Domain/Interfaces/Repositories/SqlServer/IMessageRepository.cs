using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer;

public interface IMessageRepository : ISqlServerRepositoryBase<Message>
{
    Task<List<Message>> GetLastTwentyMessages(int pageNumber, int conversationId);
}
