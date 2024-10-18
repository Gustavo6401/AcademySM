using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class CommentRepository : SqlServerRepositoryBase<Comment>, ICommentRepository
    {
        private readonly GroupsDbContext _context;
        public CommentRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllPostComments(int postId)
        {
            List<Comment>? list = await _context.Comments.Where(c => c.PostId == postId)
                                                         .ToListAsync();

            return list!;
        }
    }
}
