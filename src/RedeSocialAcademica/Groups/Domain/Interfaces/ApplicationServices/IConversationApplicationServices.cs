using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IConversationApplicationServices
    {
        Task Create(Conversation conversation);
        Task Delete(int id);
        Task<Conversation> Get(int id);
        Task<Conversation> GetByName(string name);
        Task Update(Conversation conversation);
    }
}
