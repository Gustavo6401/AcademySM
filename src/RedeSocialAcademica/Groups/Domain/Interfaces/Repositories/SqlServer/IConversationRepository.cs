using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IConversationRepository : ISqlServerRepositoryBase<Conversation>
    {
        Task<Conversation> GetByName(string name);
    }
}
