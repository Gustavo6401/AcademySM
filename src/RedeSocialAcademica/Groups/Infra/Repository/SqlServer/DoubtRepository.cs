using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class DoubtRepository : SqlServerRepositoryBase<Doubt>, IDoubtRepository
    {
        private readonly GroupsDbContext _context;
        public DoubtRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Doubt>> GetByGroup(int groupId)
        {
            List<Doubt>? list = await _context.Doubts.Where(d => d.GroupId == groupId)
                                                     .ToListAsync();

            return list!;
        }
    }
}
