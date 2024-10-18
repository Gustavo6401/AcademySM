using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IPostRepository : ISqlServerRepositoryBase<Post>
    {
        Task<List<Post>> GetByGroupId(int groupId);
    }
}
