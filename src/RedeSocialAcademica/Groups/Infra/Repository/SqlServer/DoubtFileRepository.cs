using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class DoubtFileRepository : SqlServerRepositoryBase<DoubtFile>, IDoubtFileRepository
    {
        private readonly GroupsDbContext _context;
        public DoubtFileRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DoubtFile>> GetByDoubtId(int id)
        {
            List<DoubtFile>? files = await _context.DoubtFiles.Where(df => df.DoubtId == id)
                                                              .ToListAsync();

            return files!;
        }
    }
}
