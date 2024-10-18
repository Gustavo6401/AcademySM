using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IAnswerCommentRepository : ISqlServerRepositoryBase<AnswerComment>
    {
        Task<List<AnswerComment>> GetByAnswerId(int answerId);
    }
}
