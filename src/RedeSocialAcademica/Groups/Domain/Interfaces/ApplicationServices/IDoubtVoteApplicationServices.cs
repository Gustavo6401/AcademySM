using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IDoubtVoteApplicationServices
    {
        Task Create(DoubtVote vote);
        Task Delete(int id);
        Task<DoubtVote> Get(int id);
        Task<List<DoubtVote>> GetByDoubt(int doubtId);
        /// <summary>
        /// Method responsible for displaying upvotes or downvotes.
        /// </summary>
        /// <param name="doubtId"></param>
        /// <returns></returns>
        Task<int> Index(int doubtId);
        Task Update(DoubtVote vote);
    }
}
