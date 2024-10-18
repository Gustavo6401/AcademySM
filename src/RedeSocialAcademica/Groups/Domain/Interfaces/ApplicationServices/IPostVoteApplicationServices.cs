using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.ApplicationServices
{
    public interface IPostVoteApplicationServices
    {
        Task Create(PostVote vote);
        Task Delete(int id);
        Task<PostVote> Get(int id);
        Task<List<PostVote>> GetAllPostVotes(int postId);
        Task<int> Index(int postId);
        Task Update(PostVote vote);
    }
}
