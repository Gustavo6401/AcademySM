using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class AnswerVoteRepository : SqlServerRepositoryBase<AnswerVote>, IAnswerVoteRepository
    {
        private readonly GroupsDbContext _context;
        public AnswerVoteRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AnswerVote>> GetAllVotes(int answerId)
        {
            List<AnswerVote>? list = await _context.AnswerVote.Where(a => a.AnswerId == answerId)
                                                              .ToListAsync();

            return list!;
        }
    }
}
