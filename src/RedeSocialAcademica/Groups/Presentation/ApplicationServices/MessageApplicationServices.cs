using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Presentation.ApplicationServices;

public class MessageApplicationServices : IMessageApplicationServices
{
    private readonly IMessageServices _services;
    private readonly IMessageRepository _repository;
    public MessageApplicationServices(IMessageServices services, IMessageRepository repository)
    {
        _services = services;
        _repository = repository;
    }
    public async Task Create(Message message)
    {
        _services.ValidateOnCreate(message);

        await _repository.Create(message);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }

    public async Task<Message> Get(int id)
    {
        Message message = await _repository.Get(id);

        return message;
    }

    public async Task<List<Message>> Index(int pageNumber, int conversationId)
    {
        List<Message> list = await _repository.GetLastTwentyMessages(pageNumber, conversationId);

        return list;
    }

    public async Task Update(Message message)
    {
        _services.ValidateOnCreate(message);

        await _repository.Update(message);
    }
}
