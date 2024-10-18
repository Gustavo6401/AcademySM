using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer;

public class ConversationRepository : SqlServerRepositoryBase<Conversation>, IConversationRepository
{
    private readonly GroupsDbContext _context;
    public ConversationRepository(GroupsDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Conversation> GetByName(string name)
    {
        Conversation? conversation = await _context.Conversation.FirstOrDefaultAsync(c => c.Title == name);

        return conversation!;
    }
}
