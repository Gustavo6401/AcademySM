using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Presentation.ApplicationServices
{
    public class ConversationUserApplicationServices : IConversationUserApplicationServices
    {
        private readonly IConversationUserRepository _repository;
        public ConversationUserApplicationServices(IConversationUserRepository repository)
        {
            _repository = repository;
        }
        public async Task Create(ConversationsUsers users)
        {
            await _repository.Create(users);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ConversationsUsers> Get(int id)
        {
            ConversationsUsers users = await _repository.Get(id);

            return users;
        }

        public async Task<List<ConversationsUsers>> GetUsersByConversationId(int conversationId)
        {
            List<ConversationsUsers> list = await _repository.GetUsersByConversationId(conversationId);

            return list;
        }

        public async Task<List<ConversationsUsers>> Index(int conversationId)
        {
            List<ConversationsUsers> list = await _repository.GetAllAdmins(conversationId);

            return list;
        }

        public async Task Update(ConversationsUsers users)
        {
            await _repository.Update(users);
        }
    }
}
