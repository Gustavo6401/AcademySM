using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IAnswerVoteApplicationServices
    {
        Task Create(AnswerVote vote);
        Task Delete(int id);
        Task<AnswerVote> Get(int id);
        Task<List<AnswerVote>> GetByAnswerId(int answerId);
        Task<int> Index(int answerId);
        Task Update(AnswerVote vote);
    }
}
