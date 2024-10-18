using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IMessageApplicationServices
    {
        Task Create(Message message);
        Task Delete(int id);
        Task<Message> Get(int id);
        Task<List<Message>> Index(int pageNumber, int conversationId);
        Task Update(Message message);
    }
}
