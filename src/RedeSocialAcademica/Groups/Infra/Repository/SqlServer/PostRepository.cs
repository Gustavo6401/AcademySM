using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class PostRepository : SqlServerRepositoryBase<Post>, IPostRepository
    {
        private readonly GroupsDbContext _context;
        public PostRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetByGroupId(int groupId)
        {
            List<Post>? list = await _context.Posts.Where(p => p.GroupId == groupId)
                                                   .ToListAsync();

            return list!;
        }
    }
}
