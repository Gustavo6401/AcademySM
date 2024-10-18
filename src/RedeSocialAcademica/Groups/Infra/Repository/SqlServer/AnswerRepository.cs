using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class AnswerRepository : SqlServerRepositoryBase<Answer>, IAnswerRepository
    {
        private readonly GroupsDbContext _context;
        public AnswerRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Answer>> GetAnswersByDoubtId(int doubtId)
        {
            List<Answer> list = await _context.Answer.Where(a => a.DoubtId == doubtId)
                                                     .ToListAsync();

            return list!;
        }
    }
}
