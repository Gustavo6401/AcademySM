using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class PostFileRepository : SqlServerRepositoryBase<PostFile>, IPostFileRepository
    {
        private readonly GroupsDbContext _context;
        public PostFileRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PostFile>> GetAllPostFiles(int postId)
        {
            List<PostFile>? list = await _context.PostFile.Where(pf => pf.PostId == postId)
                                                          .ToListAsync();

            return list!;
        }
    }
}
