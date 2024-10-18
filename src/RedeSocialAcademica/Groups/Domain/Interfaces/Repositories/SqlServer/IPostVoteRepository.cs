using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IPostVoteRepository : ISqlServerRepositoryBase<PostVote>
    {
        Task<List<PostVote>> GetAllPostVotes(int postId);
    }
}
