using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class ConversationUserRepository : SqlServerRepositoryBase<ConversationsUsers>, IConversationUserRepository
    {
        private readonly GroupsDbContext _context;
        public ConversationUserRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ConversationsUsers>> GetAllAdmins(int conversationId)
        {
            List<ConversationsUsers>? list = await _context.ConversationsUsers.Where(cu => cu.ConversationRole == "Admin"
                                                                                     ||    cu.ConversationId == conversationId)
                                                                              .ToListAsync();

            return list!;
        }

        public async Task<ConversationsUsers> GetByConversationAndUserId(Guid userId, int conversationId)
        {
            ConversationsUsers? user = await _context.ConversationsUsers.FirstOrDefaultAsync(cu => cu.UserId == userId
                                                                                            && cu.ConversationId == conversationId);

            return user!;
        }

        public async Task<List<ConversationsUsers>> GetUsersByConversationId(int conversationId)
        {
            List<ConversationsUsers>? list = await _context.ConversationsUsers.Where(cu => cu.ConversationId == conversationId)
                                                                              .ToListAsync();

            return list!;
        }
    }
}
