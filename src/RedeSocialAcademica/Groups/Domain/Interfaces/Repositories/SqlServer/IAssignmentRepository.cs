using Groups.Domain.Interfaces.Repositories.SqlServer.Base;
using Groups.Domain.Models.SqlServerModels;

namespace Groups.Domain.Interfaces.Repositories.SqlServer
{
    public interface IAssignmentRepository : ISqlServerRepositoryBase<Assignment>
    {
        Task<List<Assignment>> GetAssignmentsByCourseId(int id);
    }
}
