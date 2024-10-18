using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;

namespace Groups.Infra.Repository.SqlServer
{
    public class GroupCategoryRepository : SqlServerRepositoryBase<CategoryGroups>, IGroupCategoryRepository
    {
        private readonly GroupsDbContext _context;
        public GroupCategoryRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
