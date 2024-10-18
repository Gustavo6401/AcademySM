using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Presentation.ApplicationServices
{
    public class ConversationApplicationServices : IConversationApplicationServices
    {
        private readonly IConversationServices _services;
        private readonly IConversationRepository _repository;
        public ConversationApplicationServices(IConversationServices services, IConversationRepository repository)
        {
            _services = services;
            _repository = repository;
        }
        public async Task Create(Conversation conversation)
        {
            _services.ValidateOnCreate(conversation);

            await _repository.Create(conversation);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Conversation> Get(int id)
        {
            Conversation conversation = await _repository.Get(id);

            return conversation;
        }

        public async Task<Conversation> GetByName(string name)
        {
            Conversation conversation = await _repository.GetByName(name);

            return conversation;
        }

        public async Task Update(Conversation conversation)
        {
            _services.ValidateOnCreate(conversation);

            await _repository.Update(conversation);
        }
    }
}
