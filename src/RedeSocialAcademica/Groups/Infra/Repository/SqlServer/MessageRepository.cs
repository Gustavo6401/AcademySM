using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer;

public class MessageRepository : SqlServerRepositoryBase<Message>, IMessageRepository
{
    private readonly GroupsDbContext _context;
    public MessageRepository(GroupsDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Message>> GetLastTwentyMessages(int pageNumber, int conversationId)
    {
        List<Message> messages = await _context.Messages.Where(m => m.ConversationId == conversationId)
                                                        .Skip((pageNumber - 1) * 20)
                                                        .Take(20)
                                                        .ToListAsync();

        return messages;
    }
}
