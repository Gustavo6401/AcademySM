using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels.Aggregations;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IDoubtFileRepository : ISqlServerRepositoryBase<DoubtFile>
    {
        Task<List<DoubtFile>> GetByDoubtId(int doubtId);
    }
}
