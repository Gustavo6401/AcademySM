using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class AssignmentFileRepository : SqlServerRepositoryBase<AssignmentFile>, IAssignmentFileRepository
    {
        private readonly GroupsDbContext _context;
        public AssignmentFileRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AssignmentFile>> GetAllAssignmentFiles(int assignmentId)
        {
            List<AssignmentFile>? files = await _context.AssignmentFile.Where(af => af.AssignmentId == assignmentId)
                                                                       .ToListAsync();

            return files!;
        }
    }
}
