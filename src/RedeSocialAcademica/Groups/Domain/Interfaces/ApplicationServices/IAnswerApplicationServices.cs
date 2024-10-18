using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IAnswerApplicationServices
    {
        Task Create(Answer answer);
        Task Delete(int id);
        Task<Answer> Get(int id);
        Task<List<Answer>> Index(int doubtId);
        Task Update(Answer answer);
    }
}
