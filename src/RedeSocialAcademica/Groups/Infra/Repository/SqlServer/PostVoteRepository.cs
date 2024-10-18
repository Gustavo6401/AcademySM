using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class PostVoteRepository : SqlServerRepositoryBase<PostVote>, IPostVoteRepository
    {
        private readonly GroupsDbContext _context;
        public PostVoteRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PostVote>> GetAllPostVotes(int postId)
        {
            List<PostVote>? list = await _context.PostVote.Where(pv => pv.PostId == postId)
                                                          .ToListAsync();

            return list!;
        }
    }
}
