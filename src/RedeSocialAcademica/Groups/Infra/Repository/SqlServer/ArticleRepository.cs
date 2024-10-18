using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class ArticleRepository : SqlServerRepositoryBase<Article>, IArticleRepository
    {
        private readonly GroupsDbContext _context;
        public ArticleRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetByGroupId(int groupId)
        {
            List<Article>? list = await _context.Article.Where(a => a.GroupId == groupId)
                                                        .ToListAsync();

            return list!;
        }
    }
}
