using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class DoubtVoteRepository : SqlServerRepositoryBase<DoubtVote>, IDoubtVoteRepository
    {
        private readonly GroupsDbContext _context;
        public DoubtVoteRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DoubtVote>> GetAllVotes(int doubtId)
        {
            List<DoubtVote>? list = await _context.DoubtVote.Where(dv => dv.DoubtId == doubtId)
                                                            .ToListAsync();

            return list!;
        }
    }
}
