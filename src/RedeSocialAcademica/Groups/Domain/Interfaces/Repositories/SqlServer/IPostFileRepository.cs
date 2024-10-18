using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IPostFileRepository : ISqlServerRepositoryBase<PostFile>
    {
        Task<List<PostFile>> GetAllPostFiles(int postId);
    }
}
