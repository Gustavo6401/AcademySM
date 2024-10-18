using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class AssignmentSentRepository : SqlServerRepositoryBase<AssignmentSent>, IAssignmentSentRepository
    {
        private readonly GroupsDbContext _context;
        public AssignmentSentRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AssignmentSent>> GetAll(int assignmentId)
        {
            List<AssignmentSent>? list = await _context.AssignmentsSents.Where(ass => ass.AssignmentId == assignmentId)
                                                                        .ToListAsync();

            return list!;
        }
    }
}
