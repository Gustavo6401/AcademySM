using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IDoubtRepository : ISqlServerRepositoryBase<Doubt>
    {
        Task<List<Doubt>> GetByGroup(int groupId);
    }
}
