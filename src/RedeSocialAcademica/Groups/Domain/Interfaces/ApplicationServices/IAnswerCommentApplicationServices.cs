using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IAnswerCommentApplicationServices
    {
        Task Create(AnswerComment comment);
        Task Delete(int id);
        Task<AnswerComment> Get(int id);
        Task<List<AnswerComment>> Index(int answerId);
        Task Update(AnswerComment comment);
    }
}
