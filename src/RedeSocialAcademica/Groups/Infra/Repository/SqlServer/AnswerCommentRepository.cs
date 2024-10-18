using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.SqlServerModels.Aggregations;
using Groups.Infra.Context;
using Groups.Infra.Repository.SqlServer.Base;
using Microsoft.EntityFrameworkCore;

namespace Groups.Infra.Repository.SqlServer
{
    public class AnswerCommentRepository : SqlServerRepositoryBase<AnswerComment>, IAnswerCommentRepository
    {
        private readonly GroupsDbContext _context;
        public AnswerCommentRepository(GroupsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AnswerComment>> GetByAnswerId(int answerId)
        {
            List<AnswerComment>? list = await _context.AnswerComment.Where(ac => ac.AnswerId == answerId)
                                                                    .ToListAsync();

            return list!;
        }
    }
}
