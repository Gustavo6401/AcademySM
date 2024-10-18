using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface ICommentRepository : ISqlServerRepositoryBase<Comment>
    {
        Task<List<Comment>> GetAllPostComments(int postId);
    }
}
