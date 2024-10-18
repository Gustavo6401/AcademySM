using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IArticleRepository : ISqlServerRepositoryBase<Article>
    {
        Task<List<Article>> GetByGroupId(int groupId);
    }
}
