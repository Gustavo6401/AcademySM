using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class AssignmentRepository : SqlServerRepositoryBase<Assignment>, IAssignmentRepository
    {
        private readonly GroupsDbContext _context;
        public AssignmentRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Assignment>> GetAssignmentsByCourseId(int id)
        {
            List<Assignment>? list = await _context.Assignments.Where(t => t.GroupId == id)
                                                              .ToListAsync();

            return list!;
        }
    }
}
